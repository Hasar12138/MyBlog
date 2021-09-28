using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace MyBlog.Module
{
    public class TypeInfo :BaseId
    {
        [SugarColumn(ColumnDataType = "nvarchar(16)")]
        public string Name { get; set; }

    }
}
