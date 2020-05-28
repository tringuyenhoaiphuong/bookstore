using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private BookService _bookService;

        public CartController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            Dictionary<int, int> bookIds = CardHelper.GetAllProducts(HttpContext);
            Dictionary<Book, int> books = _bookService.FindAll(bookIds);
            string referer = Request.Headers["Referer"].ToString();
            ViewData["returnurl"] = referer;
            return View(books);
        }

        public IActionResult AddProduct(int id)
        {
            Book book = _bookService.GetById(id);
            if (book == null) return NotFound();
            CardHelper.AddProduct(HttpContext, book);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveProduct(int id)
        {
            CardHelper.RemoveProduct(HttpContext, id);
            return RedirectToAction("Index");
        }
    }

    public static class CardHelper
    {
        public static void AddProduct(HttpContext context, Book book)
        {
            string bookstr = context.Session.GetString("cart");
            Dictionary<int, int> books = new Dictionary<int, int>();
            if (!String.IsNullOrEmpty(bookstr))
                books = JsonConvert.DeserializeObject<Dictionary<int, int>>(bookstr);

            if (books.ContainsKey(book.Id))
            {
                books[book.Id]++;
            }
            else
            {
                books[book.Id] = 1;
            }

            bookstr = JsonConvert.SerializeObject(books);
            context.Session.SetString("cart", bookstr);
        }

        public static Dictionary<int, int> GetAllProducts(HttpContext context)
        {
            string bookstr = context.Session.GetString("cart");
            if (!String.IsNullOrEmpty(bookstr))
            {
                Dictionary<int, int> books = JsonConvert.DeserializeObject<Dictionary<int, int>>(bookstr);
                return books;
            }
            else
            {
                return new Dictionary<int, int>();
            }
        }

        public static void RemoveProduct(HttpContext context, int id)
        {
            string bookstr = context.Session.GetString("cart");
            Dictionary<int, int> books = new Dictionary<int, int>();
            if (!String.IsNullOrEmpty(bookstr))
                books = JsonConvert.DeserializeObject<Dictionary<int, int>>(bookstr);
            if (books.ContainsKey(id))
                books.Remove(id);
            bookstr = JsonConvert.SerializeObject(books);
            context.Session.SetString("cart", bookstr);
        }
    }
}
