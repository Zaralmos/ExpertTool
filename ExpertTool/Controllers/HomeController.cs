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


        // Представляет главную страницу
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            ViewBag.User = _context.Experts.Find(HttpContext.Session.GetInt32("Id")) as User ?? _context.Admins.Find(HttpContext.Session.GetInt32("Id"));
            return View();
        }

        [HttpPost]
        public IActionResult Profile(User user)
        {
            if (HttpContext.Session.GetString(AUTHORIZED) == nameof(Expert))
            {
                Expert expert = _context.Experts.Find(Id);
                // обновление базы данных...
            }
            return Redirect("~/Home/Profile");
        }

        #region Authentification
        private const string AUTHORIZED = "Authorized";
        private bool Authorized => HttpContext.Session.Keys.Contains(AUTHORIZED);
        private int? Id => HttpContext.Session.GetInt32("Id");

        [HttpGet]
        public IActionResult Auth() // Любые запросы проходят через это действие. Сюда редиректятся все действия, если человек не авторизован.
        {
            IActionResult result = null;
            if (Authorized) // Если человек авторизован
                result = Redirect("~/Home/Index"); // Редиректим его на главную
            else
                result = View(); //  Иначе отправляем юзера на страницу авторизации
            return result;
        }

        [HttpPost]
        public IActionResult Auth(string email, string password)
        {
            User user = FindUser(email, password);
            if (user != null)
            {
                HttpContext.Session.SetString(AUTHORIZED, user is Admin ? nameof(Admin) : nameof(Expert));
                HttpContext.Session.SetInt32("Id", user.Id);
            }
            else
            {
                ViewBag.Password = password;
                ViewBag.Email = email;
                ViewBag.Error = "Сочетание E-mail и пароля не найдено. Попробуйте снова.";
                return View();
            }
            return Redirect("~/Home/Index");
        }

        // позволяет разлогиниться
        public IActionResult DeAuth()
        {
            if (Authorized)
                HttpContext.Session.Remove(AUTHORIZED);
            return LocalRedirect("~/Home/Auth");
        }

        [NonAction]
        public override void OnActionExecuting(ActionExecutingContext context) // пержде чем начнётся обработка любого запроса, проверяем
        {
            if (!Authorized && HttpContext.Request.Path != "/Home/Auth") //  если человек не авторизован и при этом ещё и не направляется на страницу авторизации
            {
                context.Result = LocalRedirect("~/Home/Auth"); // перенаправляем его на страницу авторизации
            }
            base.OnActionExecuting(context); // идём дальше
        }

        // Проверяет наличие в базе данных пользователя с хаданными E-mail и паролем.
        private User FindUser(string email, string password)
        {
            User user = _context.Experts.FirstOrDefault(expert => expert.Email == email) as User
                ?? _context.Admins.FirstOrDefault(admin => admin.Email == email);
            return user?.Password == password ? user : null;
        } 
        #endregion
    }
}
