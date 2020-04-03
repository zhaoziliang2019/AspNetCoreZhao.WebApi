#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2020 精英智通, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[zzl]   时间：2020/4/3 18:00:36
 * 文件名：AppSecretConfig
 * 版本：V1.0.0
 * 
 * 修改者：   zzl        时间：   2020/4/3 18:00:36            
 * 修改说明：
 * ========================================================================
*/
#endregion

using System.IO;

namespace AspNetCoreZhao.WebApi.Commons.DB
{
    public class AppSecretConfig
    {
        private static string Audience_Secret = Appsettings.app(new string[] { "Audience", "Secret" });
        private static string Audience_Secret_File = Appsettings.app(new string[] { "Audience", "SecretFile" });


        public static string Audience_Secret_String => InitAudience_Secret();


        private static string InitAudience_Secret()
        {
            var securityString = DifDBConnOfSecurity(Audience_Secret_File);
            if (!string.IsNullOrEmpty(Audience_Secret_File) && !string.IsNullOrEmpty(securityString))
            {
                return securityString;
            }
            else
            {
                return Audience_Secret;
            }

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
}
