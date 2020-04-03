#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2020 精英智通, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[zzl]   时间：2020/4/3 17:13:54
 * 文件名：MessageModel
 * 版本：V1.0.0
 * 
 * 修改者：   zzl        时间：   2020/4/3 17:13:54            
 * 修改说明：
 * ========================================================================
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreZhao.WebApi.Models
{
    public class MessageModel<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int status { get; set; } = 200;
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool success { get; set; } = false;
        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; } = "服务器异常";
        /// <summary>
        /// 返回数据集合
        /// </summary>
        public T response { get; set; }
    }
}
