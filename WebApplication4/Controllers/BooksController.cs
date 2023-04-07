using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class BooksController : Controller
    {
        public List<Books> FakeDataBook()
        {
            List<Books> Listbook = new List<Books>();
            if (Session["Listbook"] != null)
            {
                Listbook = Session["Listbook"] as List<Books>;
            }
            else
            {
                var book1 = new Books();
                book1.Id = 1;
                book1.Title = "Book 1";
                book1.Description = "Learning ASP.NET";
                book1.Author = "Hieu Le";

                var book2 = new Books();
                book2.Id = 2;
                book2.Title = "Book 2";
                book2.Description = "Learning CSS";
                book2.Author = "Hieu Le";
                Listbook.Add(book1);
                Listbook.Add(book2);
                Session["Listbook"] = Listbook;
            }
            return Listbook;
        }
        public ActionResult List()
        {
            return View(FakeDataBook());
        }
        // GET: Books
        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Books> Listbook = FakeDataBook();
            Books sachCanSua = Listbook.Where(s => s.Id == id).FirstOrDefault();
            return View(sachCanSua);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Edit(Books sachDaSua)
        {
            List<Books> Listbook = FakeDataBook();
            foreach (Books sach in Listbook)
            {
                if (sach.Id == sachDaSua.Id)
                {
                    sach.Title=sachDaSua.Title;
                    sach.Description=sachDaSua.Description;
                    sach.Author=sachDaSua.Author;
                    break;
                }
                
            }
            return View("list", Listbook);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}