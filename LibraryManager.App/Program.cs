namespace LibraryManager.App
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            List<Book> books =
            [
                new Book { Name = "Peter Pan", Type = "Aventure" },
                new Book { Name = "1984", Type = "Dystopie" },
                new Book { Name = "Le Capital", Type = "Économie" },
                new Book { Name = "La Ferme des Animaux", Type = "Dystopie" }
            ];
            
            var adventureBooks = books.Where(book => book.Type == "Aventure");

            foreach (var book in adventureBooks)
            {
                Console.WriteLine(book.Name);
            }
        }
    }

    public class Book
    {
        public required string Name { get; init; }
        public required string Type { get; init; }
    }
}