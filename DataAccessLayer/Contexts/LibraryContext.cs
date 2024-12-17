
using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts;


public class LibraryContext: DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Library> Libraries { get; set; }
    public DbSet<Stock> Stocks { get; set; }
}