using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExpertTool.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace ExpertTool.Controllers
{
    public class HomeController : Controller
    {
        public EtContext _context { get; set; }

        public HomeController(EtContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.HttpContext.Session.Keys.Contains("Authorized"))
            {
                bool result = true;
                try
                {
                    IFormCollection form = context.HttpContext.Request.Form;
                    if (form.Keys.Contains("Password") && form.Keys.Contains("Email"))
                    {
                        User user = FindUser(form["Password"], form["Email"]);
                        if (user != null)
                        {
                            context.HttpContext.Session.SetString("Authorized", "True");
                        }
                    }
                }
                catch { }
            }
            if (!context.HttpContext.Session.Keys.Contains("Authorized"))
                context.Result = View("~/Views/Auth/Auth.cshtml");
            base.OnActionExecuting(context);
        }

        private User FindUser(string Email, string Password) =>
            _context.Experts.FirstOrDefault(expert => expert.Email == Email) as User
                ?? _context.Admins.FirstOrDefault(admin => admin.Email == Email);

    }
}
