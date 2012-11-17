using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace TrelloAppMVC.Controllers
{
    public class BoardsController : Controller
    {
        private BoardContext db = new BoardContext();


        //
        // GET: /Boards/

        public ActionResult Index()
        {
            return View(db.Boards.ToList());
        }

        //
        // GET: /Boards/Details/5

        public ActionResult Details(string id = null)
        {
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        //
        // GET: /Boards/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Boards/Create

        [HttpPost]
        public ActionResult Create(Board board)
        {
            if (ModelState.IsValid)
            {
                db.Boards.Add(board);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(board);
        }

        //
        // GET: /Boards/Edit/5

        public ActionResult Edit(string id = null)
        {
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        //
        // POST: /Boards/Edit/5

        [HttpPost]
        public ActionResult Edit(Board board)
        {
            if (ModelState.IsValid)
            {
                db.Entry(board).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(board);
        }

        //
        // GET: /Boards/Delete/5

        public ActionResult Delete(string id = null)
        {
            Board board = db.Boards.Find(id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        //
        // POST: /Boards/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            Board board = db.Boards.Find(id);
            db.Boards.Remove(board);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult UniqueBoard(string bid)
        {
            if (db.Boards.Find(bid) == null)
                return Json(true, JsonRequestBehavior.AllowGet);
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }

   
}