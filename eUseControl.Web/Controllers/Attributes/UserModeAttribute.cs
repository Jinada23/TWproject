using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Filters;

namespace MyProject.Web.Controllers.Attributes
{
    public class AdminModAttribute : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["isAdmin"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Login", action = "Index" }));
                base.OnActionExecuting(filterContext);
            }
            else
            {
                if ((bool)HttpContext.Current.Session["isAdmin"] == false)
                {
                    filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new { controller = "Login", action = "Index" }));
                }
                base.OnActionExecuting(filterContext);

            }
        }
    }
}