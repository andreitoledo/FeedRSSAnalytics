using Altsystems.FeedRSSAnalytics.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Altsystems.FeedRSSAnalytics.Infra.Data.Orm
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            :base(options) { }

        public DbSet<ArticleMatrix> ArticleMatrix { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
