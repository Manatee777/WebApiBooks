﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book Get(int id);
        Book Add(Book book);
        void Remove(int id);
        bool Update(Book book);
    }
}
