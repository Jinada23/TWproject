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
        public ActionResult Artists(string searchString, string sortType)
        {
            ViewBag.SortNameParameter = sortType == "name" ? "name_desc" : "name";
            ViewBag.SortTypeParameter = sortType == "type" ? "type_desc" : "type";
            ViewBag.SortRegistParameter = sortType == "regDate" ? "regDate_desc" : "regDate";
            var _userData = _session.GetAllUsers(searchString, sortType);

            return View(_userData);
        }

    }
}