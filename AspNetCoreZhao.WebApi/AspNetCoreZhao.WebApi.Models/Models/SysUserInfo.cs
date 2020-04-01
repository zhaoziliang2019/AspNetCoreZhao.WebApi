using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreZhao.WebApi.Models.Models
{
    public class SysUserInfo
    {
        /// <summary>
        /// 用户ID号
        /// </summary>
        public string SID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string SName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string SPassWord { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string SEaiml { get; set; }
    }
}
