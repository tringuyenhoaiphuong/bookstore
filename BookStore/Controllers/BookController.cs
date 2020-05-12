using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        // GET: /<controller>/
        public IActionResult Detail()
        {
            Book book = new Book()
            {
                Id = 1,
                Author = "Apple", 
                Description = "Long printed dress with thin adjustable straps. V-neckline and wiring under the Dust with ruffles at the bottom of the dress.", 
                Title = "5 ways to get through your BOOK"
            };
            return View(book);
        }
    }
}
