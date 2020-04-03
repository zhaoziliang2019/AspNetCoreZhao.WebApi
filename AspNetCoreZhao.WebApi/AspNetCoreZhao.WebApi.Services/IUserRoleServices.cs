#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2020 精英智通, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[zzl]   时间：2020/4/3 16:33:31
 * 文件名：IUserRoleServices
 * 版本：V1.0.0
 * 
 * 修改者：   zzl        时间：   2020/4/3 16:33:31            
 * 修改说明：
 * ========================================================================
*/
#endregion
using AspNetCoreZhao.WebApi.Models.Models;
using AspNetCoreZhao.WebApi.Services.BASE;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreZhao.WebApi.Services
{
    public interface IUserRoleServices : IBaseServices<UserRole>
    {
    }
}
