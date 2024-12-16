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
                new Author { Id = 3, FirstName = "Dany", LastName = "Capitaine" },
                new Author { Id = 3, FirstName = "Séverine", LastName = "Lettrez" }
            };

            var books = new List<Book>
            {
                new Book
                {
                    Id = 1, Name = "Le conte de Monte Cristo", Pages = 900, Type = TypeLivre.Aventure, Rate = 10,
                    Author = authors[0]
                },
                new Book
                {
                    Id = 2, Name = "Les trois mousquetaires", Pages = 300, Type = TypeLivre.Aventure, Rate = 9,
                    Author = authors[0]
                },
                new Book
                {
                    Id = 3, Name = "Apprendre le Java mais pas sur l'île de Java", Pages = 900,
                    Type = TypeLivre.Enseignement, Rate = 10, Author = authors[1]
                },
                new Book
                {
                    Id = 4, Name = "Le RC Lens, un club pas comme les autres", Pages = 900, Type = TypeLivre.Histoire,
                    Rate = 10, Author = authors[2]
                },
                new Book
                {
                    Id = 5, Name = "La RGPD, une protection contre l 'injustice", Pages = 900,
                    Type = TypeLivre.Juridique, Rate = 10, Author = authors[3]
                },

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