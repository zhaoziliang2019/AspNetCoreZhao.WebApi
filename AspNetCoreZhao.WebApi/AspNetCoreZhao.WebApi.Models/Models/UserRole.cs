#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2020 精英智通, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[zzl]   时间：2020/4/3 15:38:49
 * 文件名：UserRole
 * 版本：V1.0.0
 * 
 * 修改者：   zzl        时间：   2020/4/3 15:38:49            
 * 修改说明：
 * ========================================================================
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreZhao.WebApi.Models.Models
{
    public class UserRole:BaseEntity
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public string UId { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public string RId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建id
        /// </summary>
        public string  CreateId { get; set; }
        /// <summary>
        /// 是否冻结
        /// </summary>
        public int IsDelete { get; set; }
    }
}
