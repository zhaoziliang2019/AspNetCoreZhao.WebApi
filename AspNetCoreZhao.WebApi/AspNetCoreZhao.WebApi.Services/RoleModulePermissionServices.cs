#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2020 精英智通, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[zzl]   时间：2020/4/3 17:37:49
 * 文件名：RoleModulePermissionServices
 * 版本：V1.0.0
 * 
 * 修改者：   zzl        时间：   2020/4/3 17:37:49            
 * 修改说明：
 * ========================================================================
*/
#endregion

using AspNetCoreZhao.WebApi.Models.Models;
using AspNetCoreZhao.WebApi.Repositorys;
using AspNetCoreZhao.WebApi.Services.BASE;
using SqlSugar;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreZhao.WebApi.Services
{
    public class RoleModulePermissionServices : BaseServices<RoleModulePermission>, IRoleModulePermissionServices
    {
        private readonly IRoleModulePermissionRepository roleModulePermissionRepository;

        public RoleModulePermissionServices(IRoleModulePermissionRepository _roleModulePermissionRepository)
        {
            roleModulePermissionRepository = _roleModulePermissionRepository;
        }

        public async Task<List<RoleModulePermission>> RoleModuleMaps()
        {
            return await roleModulePermissionRepository.RoleModuleMaps();
        }
    }
}
