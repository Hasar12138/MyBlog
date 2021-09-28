using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.ISevice;
using MyBlog.Module;
using PersonalBlog.WebAPI.Utility.ApiResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogNewsController : ControllerBase
    {
        private readonly IBlogNewsService _iBlogNewsService;
        public BlogNewsController(IBlogNewsService iBlogNewsService)
        {
            this._iBlogNewsService = iBlogNewsService;
        }
        [HttpGet("BlogNews")]
        public async Task<ActionResult<ApiResult>> GetBlogNews()
        {
            var data = await _iBlogNewsService.QueryAsync();
            if (data.Count == 0) return ApiResultHelper.Error("没有更多的文章！！");

            return ApiResultHelper.Success(data); //code码 ：200 404  
        }
        /// <summary>
        /// 添加标题
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ActionResult<ApiResult>> Create(string title,string content,int typeid)
        {
            //数据验证
            if (title == null) return ApiResultHelper.Error("文章标题为空！！");
            BlogNews blognews = new BlogNews
            {
                PageView = 0,
                PublishTime = DateTime.Now,
                LikesNum = 0,
                Content = content,
                Title = title,
                TypeId = typeid,
                AuthorId = "A1",

            };
            bool blognews_check = await _iBlogNewsService.CreateAsync(blognews);
            if (!blognews_check) return ApiResultHelper.Error("添加失败！未能成功添加到数据库！");
            return ApiResultHelper.Success(blognews);
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            //数据验证
            bool blognews_check = await _iBlogNewsService.DeleteAsync(id);
            if (!blognews_check) return ApiResultHelper.Error("删除操作失败！！");
            return ApiResultHelper.Success(blognews_check);
        }
        [HttpPut("Edit")]
        public async Task<ActionResult<ApiResult>> Edit(int id,string title,string content,int typeid)
        {
            var blognews = await _iBlogNewsService.FindAsync(id);
            if (blognews == null) return ApiResultHelper.Error("文章不存在！");
            blognews.Title = title;
            blognews.Content = content;
            blognews.TypeId = typeid;
            bool blognews_check = await _iBlogNewsService.EditAsync(blognews);
            if (!blognews_check) return ApiResultHelper.Error("修改操作失败！");
            return ApiResultHelper.Success(blognews_check);

        }
    }
}
