using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_JSON_SD_TP6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private static List<Book> _books = new List<Book>();

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            book.Id = _books.Count + 1; // Simplesmente incrementa o ID para simulação
            _books.Add(book);

            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }
    }
}
