using Domain.Entities.User;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ISession _session;

        public LoginController()
        {
            var bl = new MyBusinessLogic();
            _session = bl.GetSessionBL();
        }
        //GET: Login
        public ActionResult Index()
        {
            if (Session["logged"] != null) { 
            if ((bool)Session["logged"] == false)
            {
                return View();
            }
            else
            {
                return RedirectToAction("MyPage", "Home");
            }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLogin login)
        {
            if (ModelState.IsValid)
            {

                ULoginData data = new ULoginData
                {
                    Username = login.Username,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now
                };

                var userLogin = _session.UserLogin(data);
                if (userLogin.Status)
                {
                    Session["User"] = login.Username;
                    Session["Logged"] = true;
                    Session["info"] = userLogin.Info;
                    Session["name"] = userLogin.Name;
                    Session["date"] = userLogin.date;
                    Session["prof"] = userLogin.Role;
                    if (userLogin.Role == 0)
                    {
                        Session["isAdmin"] = true;
                    }
                    else
                    {
                        Session["isAdmin"] = false;
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }
            }
            return View();
        }

        public ActionResult Loggout()
        {
            Session["Logged"] = false;
            Session["isAdmin"] = false;
            return RedirectToAction("Index", "Login");
        }
    }
}