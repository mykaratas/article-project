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

    public class ArticleService : Repository<Article>, IArticleRepository
    {
        private int searchcount { get; set; }


        public ArticleService(articlecontext context) : base(context)
        {
            searchcount = 0;
        }

        public List<Article> Search(ArticleSearchModel searchModel, int pageSize = 50, int pageNo = 1)
        {
            int skip = (pageNo - 1) * pageSize;
            var business = new ArticleBusinessLogic(_context);
            var model = business.GetArticles(searchModel);
            searchcount = model.Count();
            return model.AsEnumerable().Skip(skip).Take(pageSize).ToList();
        }

        public int GetSearchCount()
        {
            return searchcount;
        }

    }
}