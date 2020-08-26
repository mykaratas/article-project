using System;
namespace article.business.helpers.Searching
{
    public class ArticleSearchModel
    {
        public Guid? Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }

        public ArticleSearchModel(Guid? ıd, string content, string title, string name)
        {
            Id = ıd;
            Content = content;
            Title = title;
            Name = name;
        }
    }
}
