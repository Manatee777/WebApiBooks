using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BookController : ApiController
    {
        static readonly IBookRepository bookRepository = new BookRepository();

        public IEnumerable<Book> GetAllBooks()
        {
            return bookRepository.GetAll();
        }

        public HttpResponseMessage GetBook(int id)
        {
            Book book = bookRepository.Get(id);
            if (book == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "not found via id");
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, book);
            }

        }

        public IEnumerable<Book> GetBooksByType(string type)
        {
            return bookRepository.GetAll().Where(s => string.Equals(s.type, type, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Book> GetBooksByYear(int year)
        {
            return bookRepository.GetAll().Where(s => string.Equals(s.year.ToString(), year.ToString(), StringComparison.OrdinalIgnoreCase));
        }

#if true
        
#endif
        public HttpResponseMessage PostBook(Book book)
        {
            book = bookRepository.Add(book);
            var response = Request.CreateResponse<Book>(HttpStatusCode.Created, book);
            string uri = Url.Link("DefaultApi", new { id = book.id }); //default api opet v webapiconfig souboru
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public HttpResponseMessage PutBook(int id, Book book)
        {
            book.id = id;
            if (!bookRepository.Update(book))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "unable");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }


        }

        public HttpResponseMessage DeleteBook(int id)
        {
            bookRepository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
