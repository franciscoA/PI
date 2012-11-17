using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrelloAppMVC.Models;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace TrelloAppMVC.Controllers
{
    public class UsersController : Controller
    {
        private UserContext db = new UserContext();
        private MD5 md5Hash = MD5.Create();

        //
        // GET: /Users/

        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        // GET: /Users/Confirm

        public ActionResult Confirm()
        {
            return View();
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(string id = null)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.password = GetMd5Hash(md5Hash,user.password);
                user.foto = "";
                user.role = "member";
                user.active = false;
                db.Users.Add(user);
                db.SaveChanges();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com",587);
                SmtpServer.Credentials = new System.Net.NetworkCredential("aluno33731", "ISEL MVC");
                SmtpServer.EnableSsl = true;

                mail.From = new MailAddress("aluno33731@gmail.com");
                mail.To.Add(user.email);
                mail.Subject = "Regist Confirm";
                mail.Body = "To confirm regist follow the link: http://localhost:13365/Users/Activate?user=" +user.username;

                SmtpServer.Send(mail);
                return RedirectToAction("Confirm");
            }

            return View(user);
        }

        //
        // GET: /Users/Activate

        public ActionResult Activate(string user)
        {
            User targetUser = db.Users.First<User>(u => u.username == user);
            if (targetUser == null)
            {
                return HttpNotFound();
            }
            targetUser.active = true;
            db.Entry(targetUser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Logon");
        }

        //
        // GET: /Users/Logon

        public ActionResult Logon(string ReturnUrl)
        {
            if (ReturnUrl != null && ReturnUrl.Equals("/"))
                return Redirect("http://localhost:13365/Home");
            ViewBag.url = ReturnUrl;
            return View();
        }

        //
        // POST: /Users/Logon

        [HttpPost]
        public ActionResult Logon(User user)
        {
            User targetUser = db.Users.Find(user.username);
            if (targetUser!=null && VerifyMd5Hash(md5Hash, user.password, targetUser.password) && targetUser.active)
            {
                FormsAuthentication.SetAuthCookie(targetUser.username, false);
                string url = TempData["url"] as string;
                if (url != null)
                    FormsAuthentication.RedirectFromLoginPage(targetUser.username, false);
                else
                    return RedirectToRoute("Default","Boards");
            }

            return View(user);
        }

        //
        // GET: /Users/Edit/5

        public ActionResult Edit(string id = null)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /Users/Delete/5

        public ActionResult Delete(string id = null)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

 
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            string hashOfInput = GetMd5Hash(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}