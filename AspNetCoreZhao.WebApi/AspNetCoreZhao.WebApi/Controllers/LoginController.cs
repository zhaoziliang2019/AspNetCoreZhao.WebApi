using AspNetCoreZhao.WebApi.Commons.Helper;
using AspNetCoreZhao.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCoreZhao.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Login/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISysUserInfoServices sysUserInfoServices;

        public LoginController(ISysUserInfoServices _sysUserInfoServices)
        {
            sysUserInfoServices = _sysUserInfoServices;
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
            { }
             return new JsonResult("123");
        }
    }
}