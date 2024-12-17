using BusinessObjects.Entity;
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

            foreach (var book in books)
            {
                Console.WriteLine(book.Name);
            }

        }
    }
}