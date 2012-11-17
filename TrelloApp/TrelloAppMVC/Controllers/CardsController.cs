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
    public class CardsController : Controller
    {
        private CardContext db = new CardContext();

        //
        // GET: /Cards/

        public ActionResult Index()
        {

            string bid = TempData["bid"] as string;
            string lid = TempData["lid"] as string;
            ViewBag.bid = bid;
            ViewBag.lid = lid;
            var cards = db.Cards.Where<Card>(c => c.bid == bid && c.lid == lid);
            return View(cards.ToList());
        }

        //
        // GET: /Cards/Details/5

        public ActionResult Details(string cid = null, string bid = null)
        {
            Card card = db.Cards.Find(cid,bid);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        //
        // GET: /Cards/Archive/5

        public ActionResult Archive(string cid = null, string bid = null)
        {
            Card card = db.Cards.Find(cid, bid);
            if (card == null)
            {
                return HttpNotFound();
            }
            card.archived = true;
            db.Entry(card).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Cards/Create

        public ActionResult Create()
        {
            ViewBag.bid = TempData["bid"] as string;
            ViewBag.lid = TempData["lid"] as string;
            return View();
        }

        //
        // POST: /Cards/Create

        [HttpPost]
        public ActionResult Create(Card card)
        {
            card.bid = TempData["bid"] as string;
            card.lid = TempData["lid"] as string;
            if (ModelState.IsValid)
            {
                card.cardPos = db.Cards.Where<Card>(c => c.bid == card.bid && c.lid == card.lid).Count() + 1;
                card.cdate = DateTime.Now;
                card.archived = false;
                db.Cards.Add(card);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bid = card.bid;
            ViewBag.lid = card.lid;
            return View(card);
        }

        //
        // GET: /Cards/Edit/5

        public ActionResult Edit(string cid = null, string bid = null)
        {
            Card card = db.Cards.Find(cid,bid);
            if (card == null)
            {
                return HttpNotFound();
            }
            TempData["oldPos"] = card.cardPos;
            ViewBag.bid = card.bid;
            ViewBag.lid = card.lid;
            return View(card);
        }

        //
        // POST: /Cards/Edit/5

        [HttpPost]
        public ActionResult Edit(Card card)
        {
            if (ModelState.IsValid)
            {
                int newPos = card.cardPos;
                int oldPos = (int)TempData["oldPos"];
                card.cardPos = oldPos;
                db.Entry(card).State = EntityState.Modified;
                db.Cards.Remove(card);
                db.SaveChanges();
                Card otherCard = db.Cards.First<Card>(c => c.cardPos == newPos);
                string lid = otherCard.lid;
                db.Entry(otherCard).State = EntityState.Modified;
                db.Cards.Remove(otherCard);
                db.SaveChanges();
                card.cardPos = newPos;
                card.lid = TempData["lid"] as string;
                db.Cards.Add(card);
                db.SaveChanges();
                otherCard.cardPos = oldPos;
                otherCard.lid = lid;
                db.Cards.Add(otherCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bid = card.bid;
            ViewBag.lid = card.lid;
            return View(card);
        }

        //
        // GET: /Cards/Move/5

        public ActionResult Move(string cid = null, string bid = null)
        {
            Card card = db.Cards.Find(cid, bid);
            if (card == null)
            {
                return HttpNotFound();
            }
            TempData["oldLid"] = card.lid;
            ViewBag.bid = card.bid;
            return View(card);
        }

        //
        // POST: /Cards/Move/5

        [HttpPost]
        public ActionResult Move(Card card)
        {
            if (ModelState.IsValid)
            {
                string newLid = card.lid;
                string oldLid = TempData["oldLid"] as string;
                card.lid = oldLid;
                db.Entry(card).State = EntityState.Modified;
                db.Cards.Remove(card);
                db.SaveChanges();

                var cardsOfBoard = db.Cards.Where<Card>(c => c.bid == card.bid);

                var cards = cardsOfBoard.Where<Card>(c => c.lid == oldLid && c.cardPos > card.cardPos);
                foreach (Card c in cards)
                    c.cardPos--;
                db.SaveChanges();

                card.cardPos = cardsOfBoard.Where<Card>(c => c.lid == newLid).Count() + 1;
                card.lid = newLid;
                db.Cards.Add(card);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.bid = card.bid;
            ViewBag.lid = card.lid;
            return View(card);
        }

        //
        // GET: /Cards/Delete/5

        public ActionResult Delete(string cid = null, string bid = null)
        {
            Card card = db.Cards.Find(cid,bid);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        //
        // POST: /Cards/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string cid, string bid)
        {
            Card card = db.Cards.Find(cid, bid);
            db.Cards.Remove(card);
            db.SaveChanges();
            var cards = db.Cards.Where<Card>(c => c.bid == card.bid && c.cardPos > card.cardPos);
            foreach (Card c in cards)
                c.cardPos--;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public JsonResult CheckPos(int cardPos)
        {
            string bid = TempData["bid"] as string;
            string lid = TempData["lid"] as string;
            if (cardPos > 0 && cardPos <= db.Cards.Where<Card>(c => c.bid == bid && c.lid ==lid).Count())
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckLists(string lid)
        {
            string bid = TempData["bid"] as string;

            List dest = db.Lists.Where<List>(l => l.bid == bid).First<List>(l => l.lid == lid);
            if (dest != null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}