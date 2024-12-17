using BusinessObjects.Entity;
using DataAccessLayer.Contexts;
using DataAccessLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace LibraryManager.App
{
    public static class Program
    {
        private static IHost CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    var databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                        "..",
                        "..",
                        "..",
                        "..",
                        "DataAccessLayer", 
                        "Ressources", 
                        "library.db");
                    services.AddDbContext<LibraryContext>(options =>
                        options.UseSqlite($"Data Source={databasePath}"));
                    services.AddTransient<IGenericRepository<Book>, BookRepository>();
                })
                .Build();
        }
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder();
            var bookRepository = host.Services.GetRequiredService<IGenericRepository<Book>>();
            var books = bookRepository.GetAll();

            foreach (var book in books)
            {
                Console.WriteLine(book.Name);
            }

        }
    }
}