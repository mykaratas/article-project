using System.Runtime.InteropServices;

namespace article.data.models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Category : CoreEntity
    {
        [
            Required,
            MaxLength(100)
        ] 
        public string CategoryName { get; set; }
        public string Description { get; set; }
        
        public ICollection<ArticleCategory> ArticleCategories { get; set; }
        
        public Category() { }
    
        public Category(string categoryName, string description)
        {
            CategoryName = categoryName;
            Description = description;
        }
    }
}