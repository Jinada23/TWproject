using Domain.Entities.User;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace eUseControl.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ISession _session;
        public UserController()
        {
            var bl = new MyBusinessLogic();
            _session = bl.GetSessionBL();
        }

        public ActionResult LoadInfo(UserPageInput pageInput)
        {
            UserPageInputDTO data = new UserPageInputDTO
            {
                ImgUrl = pageInput.ImgUrl,
                Genre = pageInput.Genre,
                Tags = pageInput.Tags,
                Instruments = pageInput.Instruments
            };

            _session.LoadProfileInfo(((UserData)Session["user"]).Username, data);


            UserData userData = _session.userData(((UserData)Session["user"]).Username);
            Session["User"] = userData;
            return RedirectToAction("Users", "User", new { ((UserData)Session["user"]).Id});
        }

        [HttpGet]
        public ActionResult Users(int? id)
        {
            if (id != null)
            {
                UserData _userData = _session.getUserByID(id.Value);

                if (_userData.Name != null)
                {
                    return View(_userData);
                }
                else
                {
                    return RedirectToAction("Artists", "Home");
                }
            }
            else
            {
                return RedirectToAction("Artists", "Home");
            }
        }

    }
}