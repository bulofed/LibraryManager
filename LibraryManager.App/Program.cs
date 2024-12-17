using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;
using Services.Services;

namespace LibraryManager.App
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var bookRepo = new BookRepository();

            Console.WriteLine("Tous les livres d'aventure :");
            foreach (var book in bookRepo.GetByType("Aventure"))
            {
                Console.WriteLine($"- {book.Name} par {book.Author?.FirstName} {book.Author?.LastName}");
            }
            var test = new CatalogManager(bookRepo);
            Console.WriteLine(test.GetCatalog());
        }
    }
}