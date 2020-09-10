using System.ComponentModel.DataAnnotations.Schema;

namespace article.data.models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Article : CoreEntity
    {
        [
            Required,
            MaxLength(100)
        ]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public string FullName { get; set; }
        public ICollection<ArticleCategory> ArticleCategories { get; set; }

    }
}