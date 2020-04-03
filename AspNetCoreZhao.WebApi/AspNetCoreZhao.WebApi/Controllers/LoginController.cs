using AspNetCoreZhao.WebApi.AuthHelper.Policys;
using AspNetCoreZhao.WebApi.Commons.Helper;
using AspNetCoreZhao.WebApi.Models;
using AspNetCoreZhao.WebApi.Models.Models.ViewModel;
using AspNetCoreZhao.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetCoreZhao.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Login/")]
    [AllowAnonymous]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISysUserInfoServices sysUserInfoServices;
        private readonly PermissionRequirement requirement;
        private readonly IRoleModulePermissionServices roleModulePermissionServices;

        public LoginController(ISysUserInfoServices _sysUserInfoServices, PermissionRequirement _requirement, IRoleModulePermissionServices _roleModulePermissionServices)
        {
            sysUserInfoServices = _sysUserInfoServices;
            requirement = _requirement;
            roleModulePermissionServices = _roleModulePermissionServices;
        }
        /// <summary>
        /// 获取JWT的方法3：整个系统主要方法
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("JWTToken3.0")]
        public async Task<object> GetJwtToken3(string username = "", string password = "")
        {
            string jwtStr = string.Empty;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return new JsonResult(new
                {
                    Status = false,
                    message = "用户名或密码不能为空"
                });
            }
            password = MD5Helper.MD5Encrypt32(password);

            var user = await sysUserInfoServices.Query(d => d.SName == username && d.SPassWord == password);
            if (user.Count > 0)
            {
                var roleNames = await sysUserInfoServices.GetUserRoleNameStr(username,password);//获取该用户下所有角色名
                //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(JwtRegisteredClaimNames.Jti, user.FirstOrDefault().SID),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(requirement.Expiration.TotalSeconds).ToString()) };
                   claims.AddRange(roleNames.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));
                var data = await roleModulePermissionServices.RoleModuleMaps();
                var list = (from item in data
                            where item.IsDeleted == false
                            orderby item.Id
                            select new PermissionItem
                            {
                                Url = item.Module?.LinkUrl,
                                Role = item.Role?.RName,
                            }).ToList();

                requirement.Permissions = list;

                //用户标识
                var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                identity.AddClaims(claims);

                var token = JwtToken.BuildJwtToken(claims.ToArray(), requirement);
                return new MessageModel<TokenInfoViewModel>()
                {
                    success = true,
                    msg = "获取成功",
                    response = token
                };
            }
            else
            {
                return new MessageModel<TokenInfoViewModel>()
                {
                    success = false,
                    msg = "认证失败",
                };
            }
        }
    }
}