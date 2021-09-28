using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyBlog.ISevice;
using PersonalBlog.JWT.Utility.ApiResult;
using PersonalBlog.JWT.Utility.MD5;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.JWT.Controllers.Utility
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorInfoService _iAuthorInfoService;
        public AuthorizeController(IAuthorInfoService iAuthorInfoService)
        {
            _iAuthorInfoService = iAuthorInfoService;
        }
        [HttpPost("Login")]
        public async Task<ApiResult> Login(string username, string userpwd)
        {
            //加密后的密码
            string pwd = MD5Helper.EncryptMD5(userpwd);
            //数据校验
            var author = await _iAuthorInfoService.FindAsync(c => c.UserAcount == username && c.UserPwd == pwd);
            if (author != null)
            {
                //登陆成功
                var claims = new Claim[]
                {
                    //不能放敏感信息
                    new Claim(ClaimTypes.Name,author.Name),
                    new Claim("Id",author.Id.ToString()),
                    new Claim("UserAcount",author.UserAcount),
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Sdmc-CJAS1-SAD-DFSFA-SADHJVF-VF"));
                var token = new JwtSecurityToken(
                    issuer: "http://localhost:6060",
                    audience: "http://localhost:5000",  //WEB API的地址
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                    );
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return ApiResultHelper.Success(jwtToken);

            }
            else
            {
                //登陆失败
                return ApiResultHelper.Error("账户或密码错误！！");
            }

        }
    }
}
