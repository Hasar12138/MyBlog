using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalBlog.JWT.Utility.ApiResult
{
    public class ApiResult
    {
        public int Code { get; set; }//状态子码
        public string Msg { get; set; }
        public int Total { get; set; } //分页总数
        public dynamic Data { get; set; }
    }
}
