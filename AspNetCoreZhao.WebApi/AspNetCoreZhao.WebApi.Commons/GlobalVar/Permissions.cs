#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2020 精英智通, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[zzl]   时间：2020/4/3 18:09:27
 * 文件名：Permissions
 * 版本：V1.0.0
 * 
 * 修改者：   zzl        时间：   2020/4/3 18:09:27            
 * 修改说明：
 * ========================================================================
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreZhao.WebApi.Commons.GlobalVar
{

    /// <summary>
    /// 权限变量配置
    /// </summary>
    public static class Permissions
    {
        public const string Name = "Permission";
    }

    /// <summary>
    /// 路由变量前缀配置
    /// </summary>
    public static class RoutePrefix
    {
        /// <summary>
        /// 前缀名
        /// 如果不需要，尽量留空，不要修改
        /// 除非一定要在所有的 api 前统一加上特定前缀
        /// </summary>
        public const string Name = "";
    }
}
