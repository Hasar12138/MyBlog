using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Module;
using MyBlog.IRepository;


namespace MyBlog.Repository
{
    public  class AuthorInfoRepository: BaseRepository<AuthorInfo>, IAuthorInfoRepository
    {
    }
}
