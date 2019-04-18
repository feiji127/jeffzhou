using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFarming.Web.Models
{

    /// <summary>
    /// 用户资料
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nickname { get; set; }
    }
}
