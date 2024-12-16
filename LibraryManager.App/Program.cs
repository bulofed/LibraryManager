using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;

namespace LibraryManager.App
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var authors = new List<Author>
            {
                new Author { Id = 1, FirstName = "Alexandre", LastName = "Dumas" },
                new Author { Id = 2, FirstName = "Remy", LastName = "Synave" },
                new Author { Id = 3, FirstName = "Dany", LastName = "Capitaine" }
            };

            var books = new List<Book>
            {
                new Book { Id = 1, Name = "Le conte de Monte Cristo", Pages = 900, Type = TypeLivre.Aventure, Rate = 10, Author = authors[0] },
                new Book { Id = 2, Name = "Les trois mousquetaires", Pages = 300, Type = TypeLivre.Aventure, Rate = 9, Author = authors[0] }
            };

            var bookRepo = new BookRepository(books);

            Console.WriteLine("Tous les livres d'aventure :");
            foreach (var book in bookRepo.GetByType("Aventure"))
            {
                Console.WriteLine($"- {book.Name} par {book.Author.FirstName} {book.Author.LastName}");
            }
        }
    }
}