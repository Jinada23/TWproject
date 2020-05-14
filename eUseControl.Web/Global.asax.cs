using Domain.Entities.User;
using eUseControl.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace eUseControl.Web

{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AcquireRequestState()
        {
            var loggedInUsers = (Dictionary<int, DateTime>)HttpRuntime.Cache["LoggedInUsers"];
            if (Session["User"] != null)
            {
                if (((UserData)Session["User"]).Status)
                {
                    var userName = ((UserData)Session["User"]).Id;
                    if (loggedInUsers != null)
                    {
                        loggedInUsers[userName] = DateTime.Now;
                        HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
                    }
                }

                if (loggedInUsers != null)
                {
                    foreach (var item in loggedInUsers.ToList())
                    {
                        if (item.Value < DateTime.Now.AddMinutes(-10))
                        {
                            loggedInUsers.Remove(item.Key);
                        }
                    }
                    HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
                }
            }
        }

    }
}