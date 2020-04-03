using AspNetCoreZhao.WebApi.Models.Models;
using AspNetCoreZhao.WebApi.Services.BASE;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreZhao.WebApi.Services
{
    public interface ISysUserInfoServices : IBaseServices<SysUserInfo>
    {
        Task<string> GetUserRoleNameStr(string name, string password);
    }
}
