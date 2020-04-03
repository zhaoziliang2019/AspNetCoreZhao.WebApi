#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2020 精英智通, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[zzl]   时间：2020/4/3 15:15:33
 * 文件名：Role
 * 版本：V1.0.0
 * 
 * 修改者：   zzl        时间：   2020/4/3 15:15:33            
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
    public class Role:BaseEntity
    {
        /// <summary>
        /// 角色名
        /// </summary>
        public string RName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string RDiscription { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int ROrderSort { get; set; }
        /// <summary>
        /// 是否冻结
        /// </summary>
        public int REnable { get; set; }
        /// <summary>
        /// 创建id
        /// </summary>
        public string RCreateId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? RCreateTime { get; set; } = System.DateTime.Now;
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool? IsDeleted { get; set; }
    }
}
