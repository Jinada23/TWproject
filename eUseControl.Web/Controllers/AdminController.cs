using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Web.Models;
using MyProject.Web.Controllers.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISession _session;

        public AdminController()
        {
            var bl = new MyBusinessLogic();
            _session = bl.GetSessionBL();
        }

        [AdminMod]
        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        [AdminMod]
        public ActionResult DeleteUser(string name)
        {
            var user = new Domain.Entities.User.ULoginData
            {
                Username = name
            };

            var userDelet = _session.DeleteUser(user);
            if (userDelet)
            {
                ViewBag.Status = "Successful deletion!";
                return RedirectToAction("Admin", "Admin");

            }
            else
            {
                ViewBag.Status = "Unsuccessful deletion!";
                return RedirectToAction("Admin", "Admin");

            }

        }

    }
}