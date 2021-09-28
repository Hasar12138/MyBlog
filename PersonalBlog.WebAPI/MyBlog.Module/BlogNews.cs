using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MyBlog.Module
{
    public class BlogNews :BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(32)")]
        public string Title { get; set; }
        [SugarColumn(ColumnDataType = "text")]
        public string Content { get; set; }

        public DateTime PublishTime { get; set; }

        public int PageView { get; set; }

        public int LikesNum { get; set; }



        public int TypeId { get; set; }


        public string AuthorId { get; set; }


        /// <summary>
        /// 不映射到数据库的类型
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public TypeInfo TypeInfo { get; set; }
        [SugarColumn(IsIgnore = true)]
        public AuthorInfo AuthorInfo { get; set; }
    }
}
