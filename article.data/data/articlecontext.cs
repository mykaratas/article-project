namespace article.data.context
{
    using models;
    using Microsoft.EntityFrameworkCore;
    public class articlecontext : DbContext
    {
        public articlecontext(DbContextOptions<articlecontext> options)
        : base(options) { }
        public virtual DbSet<Article> Articles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>().HasData(
                new Article { Title = "Article Title 1", Content = "Article Content 1", FullName = "Full Name 1"},
                new Article { Title = "Article Title 2", Content = "Article Content 2", FullName = "Full Name 2" },
                new Article { Title = "Article Title 3", Content = "Article Content 3", FullName = "Full Name 3" }
             );
        }
    }
}

