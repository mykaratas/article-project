using System.Linq;
using System.Linq.Expressions;
namespace article.business.repositories
{
    using System;
    using System.Collections.Generic;
    using data.models;
    using Microsoft.EntityFrameworkCore;

    public interface IRepository<T> where T : CoreEntity
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(Guid id);

        void Delete(T item);
        void Delete(Expression<Func<T, bool>> exp);


        T GetById(Guid id);
        IEnumerable<T> GetAll();
        List<T> ListAll(int pageSize = 50, int pageNo = 1);
        int GetTotalCount();
        IEnumerable<T> GetDefault(Expression<Func<T, bool>> exp);

        int Save();
        void RollBack();
        bool Any(Expression<Func<T, bool>> exp);

        IQueryable<T> GetAllQ();



    }
}