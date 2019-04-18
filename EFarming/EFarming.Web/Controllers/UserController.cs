using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EFarming.Web.Controllers
{
    /// <summary>
    /// 用户相关
    /// </summary>
    [Route("api/user")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 用户登录获取token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("gettoken")]
        public ActionResult<Models.BaseResponse<String>> GetToken(Models.RequestToken request)
        {
            if (request.username == "admin" && request.password == "admin")
            {
                var claims = new[]
               {
                   new Claim(ClaimTypes.Name, request.username)
               };
                //sign the token using a secret key.This secret will be shared between your API and anything that needs to check that the token is legit.
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //.NET Core’s JwtSecurityToken class takes on the heavy lifting and actually creates the token.
                /**
                 * Claims (Payload)
                    Claims 部分包含了一些跟这个 token 有关的重要信息。 JWT 标准规定了一些字段，下面节选一些字段:
                    iss: The issuer of the token，token 是给谁的
                    sub: The subject of the token，token 主题
                    exp: Expiration Time。 token 过期时间，Unix 时间戳格式
                    iat: Issued At。 token 创建时间， Unix 时间戳格式
                    jti: JWT ID。针对当前 token 的唯一标识
                    除了规定的字段外，可以包含其他任何 JSON 兼容的字段。
                 * */
                var token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    claims: claims,
                    audience: "yourdomain.com",
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return new Models.BaseResponse<String> { code = "1", msg = "请求成功", result = new JwtSecurityTokenHandler().WriteToken(token) };

            }

            return new Models.BaseResponse<String> { code = "0", msg = "用户名和密码错误", result = "" };
        }

        /// <summary>
        /// 根据用户名获取详细信息
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("getinfo")]
        public ActionResult<Models.BaseResponse<Models.UserInfo>> GetUserInfoByName(string username)
        {
            return new Models.BaseResponse<Models.UserInfo> { code = "1", msg = "查询成功", result = new Models.UserInfo { username = "admin", nickname = "超级管理员" } };
        }

    }
}