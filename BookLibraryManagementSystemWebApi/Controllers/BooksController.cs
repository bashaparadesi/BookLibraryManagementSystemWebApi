using BookLibraryManagementSystemWebApi.DAL;
using BookLibraryManagementSystemWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookLibraryManagementSystemWebApi.Controllers
{
    public class BooksController : ApiController
    {
        Library library= new Library();
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return library.GetBooks();
        }
        
        public IHttpActionResult GetBookById(int id)
        {
            var book = library.GetBookById(id);

            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public IHttpActionResult Post(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please enter valid book details.");
            }

            library.AddBook(book);
            return Ok("Book added successfully.");
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Book book)
        {
         
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid book details.");
            }

            book.BookID = id;

            library.UpdateBook(book); 

            return Ok("Book updated successfully.");
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            library.DeleteBook(id);
            return Ok("Book deleted successfully.");
        }
    }
}
