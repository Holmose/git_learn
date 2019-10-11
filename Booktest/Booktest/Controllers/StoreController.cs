using Booktest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Booktest.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/

        public ActionResult Index()
        {
            BookStoreEntities db = new BookStoreEntities();
            var data = db.Books;
            return View(data);
        }

        [HttpGet]
        public ActionResult Order(int id)
        {
            BookStoreEntities db = new BookStoreEntities();
            var book = db.Books.Where(b => b.BookId == id).FirstOrDefault();

            ViewBag.BookId = book.BookId;
            ViewBag.AuthorName = book.AuthorName;
            ViewBag.Title = book.Title;
            ViewBag.Price = book.Price;
            ViewBag.BookCoverUrl = book.BookCoverUrl;

            return View();
        }

        [HttpPost]
        public ActionResult Order(int BookId, int Num, string Address)
        {
            BookStoreEntities db = new BookStoreEntities();
            var order = db.Orders.OrderBy(o => o.OrderId).FirstOrDefault();
            var orderid = 1;
            if (order != null)
            {
                orderid = order.OrderId + 1;
            }
            db.Orders.Add(new Order
            {
                BookId = BookId,
                Num = Num,
                Address = Address
            });
            db.SaveChanges();
            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult AddBook()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddBook(string AuthorName, string Title, Nullable<decimal> Price, string BookCoverUrl) 
        {

            BookStoreEntities db = new BookStoreEntities();

            var book = db.Books.OrderBy(o => o.BookId).FirstOrDefault();
            var bookid = 1;
            if (book != null) 
            {
                bookid = book.BookId + 1;
            }
            db.Books.Add(new Book
                {
                    BookId = bookid,
                    AuthorName = AuthorName,
                    Title = Title,
                    Price = Price,
                    BookCoverUrl = BookCoverUrl
                });
            db.SaveChanges();
            return RedirectToAction("AddBook");
        }

        public ActionResult Details()
        {
            BookStoreEntities db = new BookStoreEntities();
            var data = db.Orders;
            return View(data);
        }
    }
}
