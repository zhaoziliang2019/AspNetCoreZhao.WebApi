using AspNetCoreZhao.WebApi.Models.Models;
using AspNetCoreZhao.WebApi.Repositorys;
using AspNetCoreZhao.WebApi.Services.BASE;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AspNetCoreZhao.WebApi.Commons.Helper;

namespace AspNetCoreZhao.WebApi.Services
{
    public class SysUserInfoServices : BaseServices<SysUserInfo>, ISysUserInfoServices
    {
        private readonly ISysUserInfoRepository sysUserInfoRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IUserRoleRepository userRoleRepository;

        public SysUserInfoServices(ISysUserInfoRepository _sysUserInfoRepository, IRoleRepository _roleRepository,IUserRoleRepository _userRoleRepository)
        {
            sysUserInfoRepository = _sysUserInfoRepository;
            roleRepository = _roleRepository;
            userRoleRepository = _userRoleRepository;
            this.BaseDal = _sysUserInfoRepository;
        }

        public async Task<string> GetUserRoleNameStr(string name, string password)
        {
            string roleName = "";
            var user = (await base.Query(f=>f.SName==name&&f.SPassWord==password)).FirstOrDefault();
            var rolelist = await roleRepository.Query(f=>f.IsDeleted == false);//查询所有角色
            if (user!=null)
            {
                var userRoles = await userRoleRepository.Query(f => f.UId == user.SID);
                if (userRoles.Count>0)
                {
                    var rlist = userRoles.Select(ur => ur.RId).ToList();
                    var roles = rolelist.Where(d => rlist.Contains(d.Id.ObjToString()));
                    roleName = string.Join(",", roles.Select(r => r.RName).ToArray());
                }
            }
            return roleName;
        }
    }
}
