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

    public class CategoryService : Repository<Category>, ICategoryRepository
    {
        public CategoryService(articlecontext context) : base(context) { }
    }
}