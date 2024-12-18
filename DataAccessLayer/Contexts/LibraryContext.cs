using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Book>()
                .Property(b => b.Type)
                .HasConversion<string>();
        }
    }
}