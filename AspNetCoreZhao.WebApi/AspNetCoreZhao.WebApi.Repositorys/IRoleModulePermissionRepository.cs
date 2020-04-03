#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2020 精英智通, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[zzl]   时间：2020/4/3 17:34:06
 * 文件名：IRoleModulePermissionRepository
 * 版本：V1.0.0
 * 
 * 修改者：   zzl        时间：   2020/4/3 17:34:06            
 * 修改说明：
 * ========================================================================
*/
#endregion
using AspNetCoreZhao.WebApi.Models.Models;
using AspNetCoreZhao.WebApi.Repositorys.BASE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreZhao.WebApi.Repositorys
{
    public interface IRoleModulePermissionRepository: IBaseRepository<RoleModulePermission>
    {
        Task<List<RoleModulePermission>> RoleModuleMaps();
    }
}
