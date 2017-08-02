using Microsoft.EntityFrameworkCore;
using FeedApp.Models;

namespace FeedApp.Database
{
    public class FeedDbContext : DbContext
    {
        public string ConnectionString { get; set; }

        public FeedDbContext(DbContextOptions options) : base(options)
        {
            //this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<FeedSource> FeedSources { get; set; }
        public DbSet<NewsItem> NewsItems { get; set; }

    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}