using System.Linq.Expressions;
namespace article.business.repositories
{
    using System;
    using System.Collections.Generic;
    using data.models;
    public interface IRepository<T> where T : CoreEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);

        void Delete(T item);
        void Delete(Expression<Func<T, bool>> exp);


        T GetById(Guid id);
        IEnumerable<T> GetAll();
        List<T> ListAll(int? limit = 15, int? start = 0);
        IEnumerable<T> GetDefault(Expression<Func<T, bool>> exp);

        int Save();
        void RollBack();
        bool Any(Expression<Func<T, bool>> exp);



    }
}