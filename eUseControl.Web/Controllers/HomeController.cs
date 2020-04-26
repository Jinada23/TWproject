using Domain.Entities.User;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession _session;
        public HomeController()
        {
            var bl = new MyBusinessLogic();
            _session = bl.GetSessionBL();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult MyPage()
        {
            if (Session["isAdmin"] != null && (bool)Session["isAdmin"] == true)
            {
                return RedirectToAction("Admin", "Admin");
            }
            else
            {
                return View();
            }

        }
        
        public ActionResult Artists(string searchString, string sortType)
        {

            var _userData = _session.userData(searchString, sortType);

            return View(_userData);
        }

    }
}