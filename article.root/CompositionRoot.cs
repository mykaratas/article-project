using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using article.business.repositories;
using article.data.context;
using article.business.services;

namespace article.root
{
    public class CompositionRoot
    {
        public CompositionRoot() { }

        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddScoped<blogcontext>();
            services.AddScoped(typeof(IArticleRepository), typeof(ArticleService));
            services.AddDbContext<blogcontext>(options =>
            options.UseSqlServer("Server=localhost,1433;Initial Catalog=article_local_db;User ID=SA;Password=P@55word;Connection Timeout=30;MultipleActiveResultSets=True", x => x.MigrationsAssembly("article.api")));
        }
    }
}