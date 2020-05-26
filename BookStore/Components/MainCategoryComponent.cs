using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Components
{
    public class MainCategoryComponent : ViewComponent
    {
        private BookService _bookService;

        public MainCategoryComponent(BookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = _bookService.GetAllCategories();
            return View(categories);
        }
    }
}
