using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManager.Filters
{
    public class AccessFilters : IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(context.HttpContext.Session.GetString("user")))
            {
                if (context.Controller.GetType() !=typeof(HomeController))
                {
                    context.Result = new RedirectResult("/Home/Login");
                }
            }
        }
    }
}
