using System.Collections.Generic;
using System.Linq;
using article.data.context;
using article.data.models;

namespace article.business.helpers.Searching
{
    public class ArticleBusinessLogic
    {
        private readonly articlecontext _articlecontext;

        public ArticleBusinessLogic(articlecontext context)
        {
            _articlecontext = context;
        }

        public IEnumerable<Article> GetArticles(ArticleSearchModel searchModel, int? limit = 15, int? start = 0)
        {
            var result = _articlecontext.Articles.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.Id != null)
                    result = result.Where(x => x.Id.Equals(searchModel.Id));
                if (!string.IsNullOrEmpty(searchModel.Name))
                    result = result.Where(x => x.FullName.Contains(searchModel.Name));
                if (!string.IsNullOrEmpty(searchModel.Content))
                    result = result.Where(x => x.Content.Contains(searchModel.Content));
                if (!string.IsNullOrEmpty(searchModel.Title))
                    result = result.Where(x => x.Title.Contains(searchModel.Title));
            }

            return result.AsEnumerable();
        }

    }
}
