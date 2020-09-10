namespace article.business.services
{
    using repositories;
    using data.models;
    using data.context;
    using article.business.helpers.Searching;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly articlecontext _context;

        public EfUnitOfWork(articlecontext context)
        {
            _context = context;
        }
        
        private IArticleRepository _articles;
        private ICategoryRepository _categories;
        
        public IArticleRepository Articles
        { 
            get
            {
                return _articles ??= new ArticleService(_context);
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                return _categories ??= new CategoryService(_context);
            }

        }
        public int SaveChanges()
        {
            try
            {
                return  _context.SaveChanges();
            }
            catch
            {
                throw;
            }        
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}