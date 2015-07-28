using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    
        public class BookRepository : IBookRepository
        {
            private List<Book> books = new List<Book>();
            private int _nextId = 1;

            public BookRepository()
            {
                Add(new Book { name = "RubyOnRails", id = 1, type = "papír", year = 2013 });
                Add(new Book { name = "AngularJS", id = 2, type = "ebook", year = 2015 });
                books.Add(new Book { name = "ASP.NET MVC", id = 5, type = "ebook", year = 2014 });
            }

            public IEnumerable<Book> GetAll()
            {
                return books;
            }

            public Book Get(int id)
            {
                return books.Find(b => b.id == id);

            }

            public Book Add(Book book)
            {
                if (book == null)
                {
                    throw new ArgumentNullException("item");
                }
                books.Add(book);
                return book;
            }



            public void Remove(int id)
            {
                books.RemoveAll(b => b.id == id);
            }


            public bool Update(Book book)
            {
                if (book == null)
                {
                    throw new ArgumentNullException("book");
                }

                int index = books.FindIndex(b => b.id == book.id);
                if (index == -1)
                {
                    return false;
                }

                books.RemoveAt(index);
                books.Add(book);
                return true;
            }


        }

   
    }
