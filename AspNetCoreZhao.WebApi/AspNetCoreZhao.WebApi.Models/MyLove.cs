#region << 版 本 注 释 >>
/*----------------------------------------------------------------
// Copyright (C) 2020 xx单位
// 版权所有。 
//
// 文件名：Love
// 文件功能描述：
//
// 
// 创建者：名字 (zhao)
// 时间：2020/4/1 21:52:13
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
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreZhao.WebApi.Models
{
    public class MyLove
    {

        public virtual string SayLoveU()
        {
            return "I ♥ U";
        }
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
    }
}
