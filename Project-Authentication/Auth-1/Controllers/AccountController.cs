using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Auth_1.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        AuthEntities db = new AuthEntities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_User user)
        {
            var count = db.tbl_User.Where(x => x.UserName == user.UserName && x.Password == user.Password).Count();
            if (count != 0)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Department");
            }
            else
            {
                TempData["Msg"] = "UserName or Password is incorrect.";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tbl_User user)
        {
            db.tbl_User.Add(user);
            db.SaveChanges();

            return View();
        }

    }
}