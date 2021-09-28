using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.ISevice;
using MyBlog.Module;
using PersonalBlog.WebAPI.Utility.ApiResult;
using PersonalBlog.WebAPI.Utility.MD5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorInfoController : ControllerBase
    {
        private readonly IAuthorInfoService _iAuthorInfoService;
        public AuthorInfoController (IAuthorInfoService iAuthorInfoService)
        {
            _iAuthorInfoService = iAuthorInfoService;
        }
        [HttpPost("Create")]
        public async Task<ApiResult> Create(string name,string useracount,string userpwd )
        {
            AuthorInfo authorinfo = new AuthorInfo
            {
                Name = name,
                UserAcount = useracount,
                //MD5加密
                UserPwd = MD5Helper.EncryptMD5(userpwd)
            };
            //判断数据库中是否有存在的账号跟添加的账号相同的数据
            var oldAuthor = await _iAuthorInfoService.FindAsync(c=>c.UserAcount == useracount);   //必须加await  ,不加的话是Task类型的数据，不是空对象!!!
            if (oldAuthor != null) return ApiResultHelper.Error("此账号已存在！");
            bool author_check = await _iAuthorInfoService.CreateAsync(authorinfo);
            if (!author_check) return ApiResultHelper.Error("此用户不存在");
            return ApiResultHelper.Success(authorinfo);
        }
        [HttpPut("Edit")]
        public async Task<ApiResult> Edit(string name)
        {
        /////未完结！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！！
            int id = Convert.ToInt32(this.User.FindFirst("Id").Value);
            var author = await _iAuthorInfoService.FindAsync(id);
            author.Name = name;
            bool author_check = await _iAuthorInfoService.EditAsync(author);
            
            if (!author_check) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success("修改成功");

        }
    }
}
