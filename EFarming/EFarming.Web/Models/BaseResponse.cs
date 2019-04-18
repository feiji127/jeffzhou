using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFarming.Web.Models
{


    /// <summary>
    /// 结果返回类
    /// </summary>
    public class BaseResponse<T>
    {
        /// <summary>
        /// 代码，0：失败，1：成功
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 相关消息（错误描述）
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 返回内容结果
        /// </summary>
        public T result { get; set; }
    }
}
