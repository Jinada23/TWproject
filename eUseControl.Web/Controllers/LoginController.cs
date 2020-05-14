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
            if (Session["User"]!= null)
            {
                if (((UserData)Session["User"]).Status == false)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Users", "User", new { ((UserData)Session["User"]).Id });
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
                    UserData userData = _session.userData(data.Username);
                    userData.Status = true;
                    Session["User"] = userData;

                    if (userData.Role == 0)
                    {
                        Session["isAdmin"] = true;
                    }
                    else
                    {
                        Session["isAdmin"] = false;
                    }

                    //if the list exists, add this user to it
                    if (HttpRuntime.Cache["LoggedInUsers"] != null)
                    {
                        //get the list of logged in users from the cache
                        var loggedInUsers = (Dictionary<int, DateTime>)HttpRuntime.Cache["LoggedInUsers"];

                        if (!loggedInUsers.ContainsKey(userData.Id))
                        {
                            //add this user to the list
                            loggedInUsers.Add(userData.Id, DateTime.Now);
                            //add the list back into the cache
                            HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
                        }
                    }
                    //the list does not exist so create it
                    else
                    {
                        //create a new list
                        var loggedInUsers = new Dictionary<int, DateTime>();
                        //add this user to the list
                        loggedInUsers.Add(userData.Id, DateTime.Now);
                        //add the list into the cache
                        HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
                    }

                    return RedirectToAction("Users", "User", new { ((UserData)Session["user"]).Id });
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
            //_session.LogOff(((UserData)Session["User"]).Username);
            Session["User"] = null;
            Session["isAdmin"] = false;

            return RedirectToAction("Index", "Login");
        }
    }
}