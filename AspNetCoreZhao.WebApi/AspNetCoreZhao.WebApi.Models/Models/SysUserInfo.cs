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
        public string SEmail { get; set; }
        /// <summary>
        /// 系统用户类型 1公司内部2客户
        /// </summary>
        public int SType { get; set; }
        /// <summary>
        /// 关联角色外键
        /// </summary>
        public string SRID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string SDisplayName { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string  SPhone { get; set; }
        /// <summary>
        /// 是否冻结
        /// </summary>
        public int SLock { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string SImgPath { get; set; }
    }
}
