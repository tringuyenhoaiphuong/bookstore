using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Data
{
    
    public class BookService
    {
        private AppDataContext appDataContext;

        public BookService(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        public ICollection<Book> ListAllBooks()
        {
            return appDataContext.Book.ToList();
        }
    }
}
