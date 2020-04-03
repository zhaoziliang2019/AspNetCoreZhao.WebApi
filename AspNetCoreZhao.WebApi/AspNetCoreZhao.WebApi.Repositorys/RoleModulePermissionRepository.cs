#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2020 精英智通, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[zzl]   时间：2020/4/3 17:35:04
 * 文件名：RoleModulePermissionRepository
 * 版本：V1.0.0
 * 
 * 修改者：   zzl        时间：   2020/4/3 17:35:04            
 * 修改说明：
 * ========================================================================
*/
#endregion

using AspNetCoreZhao.WebApi.Models.Models;
using AspNetCoreZhao.WebApi.Repositorys.BASE;
using AspNetCoreZhao.WebApi.Repositorys.UnitOfWorks;
using SqlSugar;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreZhao.WebApi.Repositorys
{
    public class RoleModulePermissionRepository: BaseRepository<RoleModulePermission>, IRoleModulePermissionRepository
    {
        public RoleModulePermissionRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {
          
        }
        /// <summary>
        /// 角色权限Map
        /// RoleModulePermission, Module, Role 三表联合
        /// 第四个类型 RoleModulePermission 是返回值
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoleModulePermission>> RoleModuleMaps()
        {
            return await QueryMuch<RoleModulePermission, Module, Role, RoleModulePermission>(
                (rmp, m, r) => new object[] {
                    JoinType.Left, rmp.ModuleId == m.Id,
                    JoinType.Left,  rmp.RoleId == r.Id
                },

                (rmp, m, r) => new RoleModulePermission()
                {
                    Role = r,
                    Module = m,
                    IsDeleted = rmp.IsDeleted
                },

                (rmp, m, r) => rmp.IsDeleted == false && m.IsDeleted == false && r.IsDeleted == false
                );
        }
    }
}
