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
    public class TypeController : ControllerBase
    {
        private readonly ITypeInfoService _iTypeInfoService; 
        public TypeController (ITypeInfoService iTypeInfoService)
        {
            this._iTypeInfoService = iTypeInfoService;
        }
        [HttpGet("Types")]
        public async Task<ApiResult> Types()
        {
            var types = await _iTypeInfoService.QueryAsync();
            if (types.Count== 0) return ApiResultHelper.Error("没有更多的类型！");
            return ApiResultHelper.Success(types);
        }
        [HttpPost("Create")]
        public async Task<ApiResult> Create(string typeName)
        {
            #region 数据验证
            if (String.IsNullOrWhiteSpace(typeName)) return ApiResultHelper.Error("文章类型不能为空！");
            #endregion
            TypeInfo type = new TypeInfo
            {
                Name = typeName
            };
            bool type_ckeck = await _iTypeInfoService.CreateAsync(type);
            if (!type_ckeck) return ApiResultHelper.Error("操作失败！");
            return ApiResultHelper.Success(type_ckeck);
        }
        [HttpPut("Edit")]
        public async Task<ApiResult> Edit (int id , string name)
        {
            var type = await _iTypeInfoService.FindAsync(id);
            if (type == null) return ApiResultHelper.Error("改文章类型不存在！");
            type.Name = name;
            bool type_ckeck = await _iTypeInfoService.EditAsync(type);
            if (!type_ckeck) return ApiResultHelper.Error("操作失败！");
            return ApiResultHelper.Success(type_ckeck);
        }
        [HttpDelete("Delete")]
        public async Task<ApiResult> Delete(int id)
        {
            bool type_check = await _iTypeInfoService.DeleteAsync(id);
            if (!type_check) return ApiResultHelper.Error("操作失败！");
            return ApiResultHelper.Success(type_check);
        }

    }
}
