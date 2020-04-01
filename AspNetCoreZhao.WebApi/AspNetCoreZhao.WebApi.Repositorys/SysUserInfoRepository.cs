using AspNetCoreZhao.WebApi.Models.Models;
using AspNetCoreZhao.WebApi.Repositorys.BASE;
using AspNetCoreZhao.WebApi.Repositorys.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreZhao.WebApi.Repositorys
{
    public class SysUserInfoRepository : BaseRepository<SysUserInfo>, ISysUserInfoRepository
    {
        public SysUserInfoRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}
