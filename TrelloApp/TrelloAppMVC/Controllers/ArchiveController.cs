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
    public class ArchiveController : Controller
    {
        //
        // GET: /Archive/

        public ActionResult Index()
        {
            CardContext db = new CardContext();
            var cards = db.Cards.Where<Card>(c => c.archived == true);
            return View(cards.ToList());
        }

    }
}
