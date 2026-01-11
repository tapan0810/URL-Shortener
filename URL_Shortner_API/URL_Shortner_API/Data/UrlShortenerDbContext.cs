using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using URL_Shortner_API.Models;

namespace URL_Shortner_API.Data
{
    public class UrlShortenerDbContext : DbContext
    {
        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShortUrl> ShortUrls => Set<ShortUrl>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortUrl>()
                .HasIndex(x => x.ShortCode)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
