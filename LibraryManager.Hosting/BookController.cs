using BusinessObjects.Entity;
using BusinessObjects.Enum;
using Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Hosting
{
    [ApiController]
    [Route("[controller]")]
    public class BookController(CatalogManager catalogManager) : ControllerBase
    {
        // GET: /books
        [HttpGet("books")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = catalogManager.GetCatalog().Select(
                    book => new
                    {
                        book.Id,
                        book.Name,
                        book.Pages,
                        Type = book.Type.ToString(),
                        book.Rate,
                    }
                );
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
                var book = catalogManager.FindBook(id);
                var result = new
                {
                    book.Id,
                    book.Name,
                    book.Pages,
                    Type = book.Type.ToString(),
                    book.Rate,
                };
                return Ok(result);
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
        
        // GET: /books/type
        [HttpGet("books/{type}")]
        public IActionResult GetBooksByType(string type)
        {
            try
            {
                if (!Enum.TryParse(typeof(TypeBook), type, true, out var typeEnum))
                {
                    return BadRequest($"Invalid TypeLivre '{type}'.");  
                }
                var books = catalogManager.GetCatalog((TypeBook)typeEnum);

                if (!books.Any())
                {
                    return NotFound($"No books found with TypeLivre '{type}'.");
                }

                var result = books.Select(book => new
                {
                    book.Id,
                    book.Name,
                    book.Pages,
                    Type = book.Type.ToString(),
                    book.Rate,
                });
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: /book/add
        [HttpGet("book/add")]
        public IActionResult AddBook(
            [FromQuery] string name, 
            [FromQuery] int pages, 
            [FromQuery] TypeBook type, 
            [FromQuery] int rate)
        {
            try
            {
                var newBook = new Book
                {
                    Name = name,
                    Pages = pages,
                    Type = type,
                    Rate = rate
                };

                catalogManager.AddBook(newBook);

                return Ok($"Book '{name}' added successfully with {pages} pages, type '{type}', and rate {rate}.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}