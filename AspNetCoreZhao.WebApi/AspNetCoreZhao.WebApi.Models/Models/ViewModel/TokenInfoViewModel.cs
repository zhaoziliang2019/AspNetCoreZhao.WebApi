#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2020 精英智通, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[zzl]   时间：2020/4/3 17:11:57
 * 文件名：TokenInfoViewModel
 * 版本：V1.0.0
 * 
 * 修改者：   zzl        时间：   2020/4/3 17:11:57            
 * 修改说明：
 * ========================================================================
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreZhao.WebApi.Models.Models.ViewModel
{
    public class TokenInfoViewModel
    {
        public bool success { get; set; }
        public string token { get; set; }
        public double expires_in { get; set; }
        public string token_type { get; set; }
    }
}
