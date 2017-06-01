using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerBooksLib.Services;
using ServerBooksLib.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksService.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly BooksContext _booksContext;
        public BooksController(BooksContext booksContext)
        {
            _booksContext = booksContext;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return _booksContext.Books.Take(100).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = nameof(GetBookById))]
        public IActionResult GetBookById(int id)
        {
            Book book = _booksContext.Books.Where(b => b.BookId == id).SingleOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult PostBook([FromBody] Book book)
        {
            _booksContext.Books.Add(book);
            _booksContext.SaveChanges();

            return CreatedAtRoute(nameof(GetBookById), new { id = book.BookId }, book);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
