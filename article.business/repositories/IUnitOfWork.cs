using System;
namespace article.business.repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }
        int SaveChanges();

    }

}