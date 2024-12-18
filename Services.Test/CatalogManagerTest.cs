using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;
using Moq;
using Services.Services;

namespace Services.Test
{
    public class CatalogManagerTest
    {
        private readonly Mock<IGenericRepository<Book?>> _mockBookRepository;
        private readonly CatalogManager _catalogManager;

        public CatalogManagerTest()
        {
            // Création d’un Mock de IGenericRepository
            _mockBookRepository = new Mock<IGenericRepository<Book?>>();

            // Initialisation de CatalogManager avec le Mock du Repository
            _catalogManager = new CatalogManager(_mockBookRepository.Object);
        }

        [Fact]
        public void GetCatalog_ShouldReturnAllBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Name = "Book 1", Type = TypeBook.Roman },
                new Book { Id = 2, Name = "Book 2", Type = TypeBook.Essai }
            };
            _mockBookRepository.Setup(repo => repo.GetAll()).Returns(books);

            // Act
            var result = _catalogManager.GetCatalog();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, b => b.Name == "Book 1");
            Assert.Contains(result, b => b.Name == "Book 2");
        }

        [Fact]
        public void GetCatalog_ByType_ShouldReturnFilteredBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Name = "Book 1", Type = TypeBook.Roman },
                new Book { Id = 2, Name = "Book 2", Type = TypeBook.Essai },
                new Book { Id = 3, Name = "Book 3", Type = TypeBook.Roman }
            };
            _mockBookRepository.Setup(repo => repo.GetAll()).Returns(books);

            // Act
            var result = _catalogManager.GetCatalog(TypeBook.Roman);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.All(result!, b => Assert.Equal(TypeBook.Roman, b.Type));
        }

        [Fact]
        public void FindBook_ShouldReturnBookById()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Name = "Book 1", Type = TypeBook.Roman },
                new Book { Id = 2, Name = "Book 2", Type = TypeBook.Essai }
            };
            _mockBookRepository.Setup(repo => repo.GetAll()).Returns(books);

            // Act
            var result = _catalogManager.FindBook(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Book 1", result.Name);
        }

        [Fact]
        public void FindBook_ShouldReturnNullIfBookNotFound()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Name = "Book 1", Type = TypeBook.Roman },
                new Book { Id = 2, Name = "Book 2", Type = TypeBook.Essai }
            };
            _mockBookRepository.Setup(repo => repo.GetAll()).Returns(books);

            // Act
            var result = _catalogManager.FindBook(3);

            // Assert
            Assert.Null(result);
        }
    }
}