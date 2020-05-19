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
        public ActionResult DeleteUser(string user)
        {
            var userDelet = _session.DeleteUser(user);
            if (userDelet)
            {
                TempData["DeleteStatus"] = "Successful deletion!";
                return RedirectToAction("Admin", "Admin");
            }
            else
            {
                TempData["DeleteStatus"] = "Unsuccessful deletion!";
                return RedirectToAction("Admin", "Admin");
            }
        }

        [HttpPost]
        public ActionResult AddAdmin(string user)
        {
            var userAdmin = _session.AddAdmin(user);
            if (userAdmin)
            {
                TempData["AddStatus"] = "Successful adding!";
            }
            else
            {
                TempData["AddStatus"] = "Unexistent user!";
                return RedirectToAction("Admin", "Admin");
            }
            return RedirectToAction("Admin", "Admin");
        }

    }
}