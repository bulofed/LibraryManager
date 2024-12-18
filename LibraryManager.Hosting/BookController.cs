using BusinessObjects.Entity;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Hosting
{
    [ApiController]
    [Route("[controller]")]
    public class BookController(IGenericRepository<Book> bookRepository) : ControllerBase
    {
        private readonly IGenericRepository<Book> _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));

        // GET: /books
        [HttpGet("books")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _bookRepository.GetAll();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: /book/{id}
        [HttpGet("book/{id}")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                var book = _bookRepository.Get(id);
                return Ok(book);
            }
            catch (InvalidOperationException)
            {
                return NotFound($"Book with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: /book/add
        [HttpGet("book/add")]
        public IActionResult AddBook([FromQuery] string name)
        {
            try
            {
                var newBook = new Book
                {
                    Name = name
                };

                _bookRepository.Add(newBook);

                return Ok($"Book '{name}' added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}