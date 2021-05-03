using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alkemy.Filters
{
    public class AutorizeAdmin : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["C_Roles"] == null)
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    {"Controller", "Home"},
                    {"Action", "Login"} 
                });
            }
            //var aux = HttpContext.Current.Session["C_Roles"];
            //if (aux != "admin")
            //{
            //    filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
            //    {
            //        {"Controller", "Home"},
            //        {"Action", "Index"}
            //    });
            //}
            //if (HttpContext.Current.Session["C_Roles"] == "admin")
            //{
            //    filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
            //    {
            //        {"Controller", "Home"},
            //        {"Action", "Index"}
            //    });
            //}
            //if (HttpContext.Current.Session["C_Roles"] == "admin")
            //{
            //    filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
            //    {
            //        {"Controller", "Home"},
            //        {"Action", "UserList"}
            //    });
            //}

            base.OnActionExecuting(filterContext);
        }
    }
}