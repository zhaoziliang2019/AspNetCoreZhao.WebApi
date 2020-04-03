﻿#region << 版 本 注 释 >>
/*
 * ========================================================================
 * Copyright(c) 2020 精英智通, All Rights Reserved.
 * ========================================================================
 *  
 * 【当前类文件的功能】
 *  
 *  
 * 作者：[zzl]   时间：2020/4/3 16:07:10
 * 文件名：RoleRepository
 * 版本：V1.0.0
 * 
 * 修改者：   zzl        时间：   2020/4/3 16:07:10            
 * 修改说明：
 * ========================================================================
*/
#endregion

using AspNetCoreZhao.WebApi.Models.Models;
using AspNetCoreZhao.WebApi.Repositorys.BASE;
using AspNetCoreZhao.WebApi.Repositorys.UnitOfWorks;

namespace AspNetCoreZhao.WebApi.Repositorys
{
    public class RoleRepository: BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}
