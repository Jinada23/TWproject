using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities.User;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic;

namespace eUseControl.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;

        public RegisterController()
        {
            var bl = new MyBusinessLogic();
            _session = bl.GetSessionBL();
        }

        public ActionResult RegisterWriter()
        {
            return View();
        }
        public ActionResult RegisterMusician()
        {
            return View();
        }
        public ActionResult RegisterProducer()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RegisterWriter(UserRegister data)
        {
           
            if (ModelState.IsValid)
            {

                URegistrationData login = new URegistrationData
                {
                    Name = data.Name,
                    Username = data.Username,
                    Password = data.Password,
                    Info = data.Info,
                    RegisterDateTime = DateTime.Now
                };

                var userRegistration = _session.UserRegister(login);
                if (userRegistration.Status)
                {
                    ViewBag.Name = "Successful registration!";
                }
                else
                {
                    ModelState.AddModelError("", userRegistration.StatusMsg);
                    return View();
                }
            }

            return View();
        }
       
        [HttpPost]
        public ActionResult RegisterMusician(UserRegister data)
        {
            if (ModelState.IsValid)
            {

                URegistrationData login = new URegistrationData
                {
                    Name = data.Name,
                    Username = data.Username,
                    Password = data.Password,
                    Info = data.Info,
                    RegisterDateTime = DateTime.Now
                };

                var userRegistration = _session.UserRegister(login);
                if (userRegistration.Status)
                {
                    ViewBag.Name = "Successful registration!";
                }
                else
                {
                    ModelState.AddModelError("", userRegistration.StatusMsg);
                    return View();
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult RegisterProducer(UserRegister data)
        {
            if (ModelState.IsValid)
            {

                URegistrationData login = new URegistrationData
                {
                    Name = data.Name,
                    Username = data.Username,
                    Password = data.Password,
                    Info = data.Info,
                    RegisterDateTime = DateTime.Now
                };

                var userRegistration = _session.UserRegister(login);
                if (userRegistration.Status)
                {
                    ViewBag.Name = "Successful registration!";
                }
                else
                {
                    ModelState.AddModelError("", userRegistration.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}