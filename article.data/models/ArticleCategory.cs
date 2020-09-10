using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace article.data.models
{
    public class ArticleCategory : CoreEntity
    {
        public Guid ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}