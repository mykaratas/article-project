namespace article.data.context
{
    using models;
    using Microsoft.EntityFrameworkCore;
    public class blogcontext : DbContext
    {
        public blogcontext(DbContextOptions<blogcontext> options)
        : base(options) { }
        public virtual DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

