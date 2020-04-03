using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreZhao.WebApi.AuthHelper.Policys
{
    /// <summary>
    /// 用户或角色或其他凭据实体,就像是订单详情一样
    /// 之前的名字是 Permission
    /// </summary>
    public class PermissionItem
    {
        /// <summary>
        /// 用户或角色或其他凭据名称
        /// </summary>
        public virtual string Role { get; set; }
        /// <summary>
        /// 请求Url
        /// </summary>
        public virtual string Url { get; set; }
    }
}
