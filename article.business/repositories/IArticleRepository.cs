namespace article.business.repositories
{
    using System.Collections;
    using article.business.helpers.Searching;
    using article.data.models;
    public interface IArticleRepository : IRepository<Article>
    {
        IEnumerable Search(ArticleSearchModel searchModel);
    }

}