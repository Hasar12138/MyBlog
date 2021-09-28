using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MyBlog.Module
{
    public class AuthorInfo :BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(12)")]
        public string Name { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(12)")]
        public string UserAcount { get; set; }
        [SugarColumn(ColumnDataType = "nvarchar(64)")]
        public string UserPwd { get; set; }
    }
}
