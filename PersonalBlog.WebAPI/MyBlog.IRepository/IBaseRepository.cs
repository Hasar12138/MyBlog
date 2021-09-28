using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Module;
using SqlSugar;

namespace MyBlog.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);  //删除主要用主键ID
        Task<bool> EditAsync(TEntity entity);
        Task<TEntity> FindAsync(int id);  //查找主要用主键ID
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func);


        //查询全部的数据

        Task<List<TEntity>> QueryAsync();

        //自定义查询

        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func);

        /// <summary>
        ///分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total);
        /// <summary>
        /// 自定义条件分页查询
        /// </summary>
        /// <param name="func"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total);
    }
}
