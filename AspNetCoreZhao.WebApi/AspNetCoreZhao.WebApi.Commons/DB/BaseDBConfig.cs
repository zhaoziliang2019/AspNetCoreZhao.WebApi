#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2020 xx单位
// 版权所有。 
//
// 文件名：BaseDBConfig
// 文件功能描述：
//
// 
// 创建者：名字 (zhao)
// 时间：2020/4/1 23:06:17
//
// 修改人：zzl
// 时间：
// 修改说明：zzl
//
// 修改人：zzl
// 时间：
// 修改说明：zzl
//
// 版本：V1.0.0
//----------------------------------------------------------------*/
#endregion
using AspNetCoreZhao.WebApi.Commons.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AspNetCoreZhao.WebApi.Commons.DB
{
    public class BaseDBConfig
    {
        public static List<MutiDBOperate> MutiConnectionString => MutiInitConn();

        public static List<MutiDBOperate> MutiInitConn()
        {
            List<MutiDBOperate> listdatabase = new List<MutiDBOperate>();
            List<MutiDBOperate> listdatabaseSimpleDB = new List<MutiDBOperate>();
            string Path = "appsettings.json";
            using (var file = new StreamReader(Path))
            using (var reader = new JsonTextReader(file))
            {
                var jObj = (JObject)JToken.ReadFrom(reader);
                if (!string.IsNullOrWhiteSpace("DBS"))
                {
                    var secJt = jObj["DBS"];
                    if (secJt != null)
                    {
                        for (int i = 0; i < secJt.Count(); i++)
                        {
                            if (secJt[i]["Enabled"].ObjToBool())
                            {
                                listdatabase.Add(SpecialDbString(new MutiDBOperate()
                                {
                                    ConnId = secJt[i]["ConnId"].ObjToString(),
                                    Conn = secJt[i]["Connection"].ObjToString(),
                                    DbType = (DataBaseType)(secJt[i]["DBType"].ObjToInt()),
                                }));
                            }
                        }
                    }
                }


                // 单库，只保留一个
                if (!Appsettings.app(new string[] { "MutiDBEnabled" }).ObjToBool())
                {
                    if (listdatabase.Count == 1)
                    {
                        return listdatabase;
                    }
                    else
                    {
                        var dbFirst = listdatabase.FirstOrDefault(d => d.ConnId == Appsettings.app(new string[] { "MainDB" }).ObjToString());
                        if (dbFirst == null)
                        {
                            dbFirst = listdatabase.FirstOrDefault();
                        }
                        listdatabaseSimpleDB.Add(dbFirst);
                        return listdatabaseSimpleDB;
                    }

                }

                return listdatabase;
            }
        }
        private static MutiDBOperate SpecialDbString(MutiDBOperate mutiDBOperate)
        {
            if (mutiDBOperate.DbType == DataBaseType.Sqlite)
            {
                mutiDBOperate.Conn = $"DataSource=" + Path.Combine(Environment.CurrentDirectory, mutiDBOperate.Conn);
            }
            else if (mutiDBOperate.DbType == DataBaseType.SqlServer)
            {
                mutiDBOperate.Conn = DifDBConnOfSecurity(@"D:\my-file\dbCountPsw1.txt", @"c:\my-file\dbCountPsw1.txt", mutiDBOperate.Conn);
            }
            else if (mutiDBOperate.DbType == DataBaseType.MySql)
            {
                mutiDBOperate.Conn = DifDBConnOfSecurity(@"D:\my-file\dbCountPsw1_MySqlConn.txt", @"c:\my-file\dbCountPsw1_MySqlConn.txt", mutiDBOperate.Conn);
            }
            else if (mutiDBOperate.DbType == DataBaseType.Oracle)
            {
                mutiDBOperate.Conn = DifDBConnOfSecurity(@"D:\my-file\dbCountPsw1_OracleConn.txt", @"c:\my-file\dbCountPsw1_OracleConn.txt", mutiDBOperate.Conn);
            }

            return mutiDBOperate;
        }
        private static string DifDBConnOfSecurity(params string[] conn)
        {
            foreach (var item in conn)
            {
                try
                {
                    if (File.Exists(item))
                    {
                        return File.ReadAllText(item).Trim();
                    }
                }
                catch (System.Exception) { }
            }

            return conn[conn.Length - 1];
        }
    }
    public enum DataBaseType
    {
        MySql = 0,
        SqlServer = 1,
        Sqlite = 2,
        Oracle = 3,
        PostgreSQL = 4
    }
    public class MutiDBOperate
    {
        public string ConnId { get; set; }
        public string Conn { get; set; }
        public DataBaseType DbType { get; set; }
    }
}
