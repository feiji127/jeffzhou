using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFarming.Web.Models
{
    public class RequestToken
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
    }
}
