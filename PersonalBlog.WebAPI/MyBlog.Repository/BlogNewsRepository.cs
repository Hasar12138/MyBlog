using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.IRepository;
using MyBlog.Module;

namespace MyBlog.Repository
{
    public class BlogNewsRepository:BaseRepository<BlogNews>,IBlogNewsRepository
    {
    }
}
