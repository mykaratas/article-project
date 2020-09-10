namespace article.data.context
{
    using models;
    using Microsoft.EntityFrameworkCore;
    public class articlecontext : DbContext
    {
        public articlecontext(DbContextOptions<articlecontext> options)
        : base(options) { }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleCategory> ArticleCategories { get; set; }
        public virtual DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ArticleCategory>().HasKey(pk => new { pk.ArticleId, pk.CategoryId });

            
            modelBuilder.Entity<ArticleCategory>()
                .HasOne(bc => bc.Article)
                .WithMany(b => b.ArticleCategories)
                .HasForeignKey(bc => bc.ArticleId);
            
            modelBuilder.Entity<ArticleCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.ArticleCategories)
                .HasForeignKey(bc => bc.CategoryId);
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>().HasData(
                new Article { Title = "Article Title 1", Content = "Article Content 1", FullName = "Full Name 1"},
                new Article { Title = "Article Title 2", Content = "Article Content 2", FullName = "Full Name 2" },
                new Article { Title = "Article Title 3", Content = "Article Content 3", FullName = "Full Name 3" }
             );
        }
    }
}

