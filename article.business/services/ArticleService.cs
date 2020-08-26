namespace article.business.services
{
    using repositories;
    using data.models;
    using data.context;
    using article.business.helpers.Searching;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Collections;

    public class ArticleService : Repository<Article>, IArticleRepository
    {
        public ArticleService(blogcontext context) : base(context) { }

        public IEnumerable Search(ArticleSearchModel searchModel)
        {
            var business = new ArticleBusinessLogic(_context);
            var model = business.GetArticles(searchModel);
            return model.AsEnumerable();
        }
    }
}