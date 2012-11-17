using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;

namespace TrelloAppMVC.Controllers
{
    public class ListsController : Controller
    {
        private ListContext db = new ListContext();

        //
        // GET: /Lists/

        public ActionResult Index()
        {
            string bid = TempData["bid"] as string;
            ViewBag.bid = bid;
            var lists = db.Lists.Where<List>(l => l.bid==bid);
            return View(lists.ToList());
        }

        //
        // GET: /Lists/Details/5

        public ActionResult Details(string lid = null, string bid = null)
        {
            List list = db.Lists.Find(lid,bid);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        //
        // GET: /Lists/Create

        public ActionResult Create()
        {
            ViewBag.bid = TempData["bid"] as string;
            return View();
        }

        //
        // POST: /Lists/Create

        [HttpPost]
        public ActionResult Create(List list)
        {
            list.bid = TempData["bid"] as string;
            if (ModelState.IsValid)
            {
                list.listPos = db.Lists.Where<List>(l => l.bid == list.bid).Count() + 1;
                db.Lists.Add(list);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bid = list.bid;
            return View(list);
        }

        //
        // GET: /Lists/Edit/5

        public ActionResult Edit(string lid = null, string bid = null)
        {
            ViewBag.bid = bid;
            List list = db.Lists.Find(lid, bid);
            if (list == null)
            {
                return HttpNotFound();
            }
            TempData["oldPos"] = list.listPos;
            return View(list);
        }

        //
        // POST: /Lists/Edit/5

        [HttpPost]
        public ActionResult Edit(List list)
        {
            if (ModelState.IsValid)
            {
              
                int newPos = list.listPos;
                int oldPos = (int)TempData["oldPos"];
                list.listPos = oldPos;
                db.Entry(list).State = EntityState.Modified;
                db.Lists.Remove(list);
                db.SaveChanges();
                List otherList = db.Lists.First<List>(l => l.listPos == newPos);
                db.Entry(otherList).State = EntityState.Modified;
                db.Lists.Remove(otherList);
                db.SaveChanges();
                list.listPos = newPos;
                db.Lists.Add(list);
                db.SaveChanges();
                otherList.listPos = oldPos;
                db.Lists.Add(otherList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bid = list.bid;
            return View(list);
        }

        //
        // GET: /Lists/Delete/5

        public ActionResult Delete(string lid = null, string bid = null)
        {
            List list = db.Lists.Find(lid,bid);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        //
        // POST: /Lists/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string lid, string bid)
        {
            List list = db.Lists.Find(lid,bid);
            db.Lists.Remove(list);
            db.SaveChanges();
            var lists = db.Lists.Where<List>(l => l.bid == list.bid && l.listPos > list.listPos);
            foreach (List l in lists)
                l.listPos--;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult UniqueList(string lid)
        {
            if (db.Boards.Find(lid) == null)
                return Json(true, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CheckPos(int listPos)
        {
           string bid = TempData["bid"] as string;
           if (listPos > 0 && listPos <= db.Lists.Where<List>(l => l.bid == bid).Count())
           {
               return Json(true, JsonRequestBehavior.AllowGet);
           }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}