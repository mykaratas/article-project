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

    public class ArticleCategoryService : Repository<ArticleCategory>, IArticleCategoryRepository
    {
        public ArticleCategoryService(articlecontext context) : base(context) { }
    }
}