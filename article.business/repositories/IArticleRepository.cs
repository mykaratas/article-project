namespace article.business.repositories
{
    using System.Collections;
    using System.Collections.Generic;
    using article.business.helpers.Searching;
    using article.data.models;
    public interface IArticleRepository : IRepository<Article>
    {
        List<Article> Search(ArticleSearchModel searchModel, int pageSize = 50, int pageNo = 1);

        int GetSearchCount();
    }

}