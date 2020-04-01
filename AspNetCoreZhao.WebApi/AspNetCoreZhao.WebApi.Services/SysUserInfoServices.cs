using AspNetCoreZhao.WebApi.Models.Models;
using AspNetCoreZhao.WebApi.Repositorys;
using AspNetCoreZhao.WebApi.Repositorys.UnitOfWorks;
using AspNetCoreZhao.WebApi.Services.BASE;

namespace AspNetCoreZhao.WebApi.Services
{
    public class SysUserInfoServices : BaseServices<SysUserInfo>, ISysUserInfoServices
    {
        private readonly ISysUserInfoRepository sysUserInfoRepository;

        public SysUserInfoServices(ISysUserInfoRepository _sysUserInfoRepository)
        {
            sysUserInfoRepository = _sysUserInfoRepository;
            this.BaseDal = _sysUserInfoRepository;
        }
    }
}
