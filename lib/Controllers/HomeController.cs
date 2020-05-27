using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Linq.Mapping;
using lib.Models;
using System.Drawing;

namespace lib.Controllers
{
    public class HomeController : Controller
    {
        booksDataContext boo = new booksDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addbook()
        {
            return View();
        }
        public ActionResult adbook()
        {
            String name = Request.Form["name"];
            String author = Request.Form["author"];
            String co = Request.Form["copies"];
            String cat = Request.Form["cat"];
            int copies = int.Parse(co);
            book b = new book();
            b.name = name;
            b.author = author;
            b.copies = copies;
            b.category = cat;
            boo.books.InsertOnSubmit(b);
            boo.SubmitChanges();
            return RedirectToAction("BookAdded");
        }
        public ActionResult show()
        {
            return View();
        }
        public ActionResult showbook()
        {
            String cat = Request.Form["cat"];
            List<book> lists = boo.books.ToList<book>();
            List<book> list = new List<book>();
            if (lists != null)
            {
                foreach (var q in lists)
                {
                    if (q.category == cat)
                        list.Add(q);
                }
            }
            if (list != null)
                return View(list);
            else return View();
        }
        public ActionResult BookAdded()
        {
            return View();
        }
        public ActionResult viewbook()
        {
            List<book> lists = boo.books.ToList<book>();
            List<book> list = new List<book>();
            if (lists != null)
            {
                foreach (var q in lists)
                {
                        list.Add(q);
                }
            }
            if (list != null)
                return View(list);
            else return View();
        }
        public ActionResult update()
        {
            List<book> lists = boo.books.ToList<book>();
            List<book> list = new List<book>();
            String ids = Request["id"];
            int id = Convert.ToInt32(ids);
            foreach (var m in lists)
            {
                if (m.id == id)
                {
                    var i = m;
                    list.Add(i);
                }
            }
            return View(list);
        }
        public ActionResult updatebook()
        {
            String bookname = Request["bookname"];
            String author = Request["author"];
            String co = Request["copies"];
            String cat = Request["cat"];
            int copies = Convert.ToInt32(co);
            String no = Request["id"];
            int id = Convert.ToInt32(no);
            book b = boo.books.First(a => a.id.Equals(id));
            b.id = id;
            b.author = author;
            b.copies = copies;
            b.name = bookname;
            b.category = cat;
            boo.SubmitChanges();
            return RedirectToAction("bookupdated");
        }
        public ActionResult bookupdated()
        {
            return View();
        }
        }
}
