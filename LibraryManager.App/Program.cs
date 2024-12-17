using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibraryManager.App
{
    public static class Program
    {
        private static IHost CreateHostBuilder(IConfigurationBuilder configuration)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<IGenericRepository<Book>, BookRepository>();
                })
                .Build();
        }
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder();
            var host = CreateHostBuilder(configuration);

            var bookRepository = host.Services.GetRequiredService<IGenericRepository<Book>>();
            var books = bookRepository.GetAll();
            
            var adventureBooks = books.Where(book => book.Type == TypeLivre.Aventure);

            foreach (var book in adventureBooks)
            {
                Console.WriteLine(book.Name);
            }

        }
    }
}