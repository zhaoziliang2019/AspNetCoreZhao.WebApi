#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2020 精英智通, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[zzl]   时间：2020/4/3 15:02:06
 * 文件名：BaseEntity
 * 版本：V1.0.0
 * 
 * 修改者：   zzl        时间：   2020/4/3 15:02:06            
 * 修改说明：
 * ========================================================================
*/
#endregion

using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreZhao.WebApi.Models.Models
{
    public class BaseEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(IsNullable = false, IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
    }
}
