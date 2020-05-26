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

        public List<Category> GetAllCategories()
        {
            return appDataContext.Category.ToList();
        }

        public List<Book> GetAllBookOfCategory(int categoryId)
        {
            var query = from b in appDataContext.Book
                        join cb in appDataContext.Categorybook on b.Id equals cb.BookId
                        where cb.CategoryId == categoryId
                        select b;
            return query.ToList();
        }
    }
}
