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
            return View();
        }

        [HttpPost]
        public IActionResult Profile(User user)
        {
            AuthorizedUser.Update(user);
            _context.SaveChanges();
            ViewBag.User = AuthorizedUser;
            return Redirect("~/Home/Profile");
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Register(string role)
        {
            ViewBag.role = role;           
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user, string role)
        {
            ViewBag.role = role;
            if (role != nameof(Admin) && role != nameof(Expert))
                ViewBag.Error = "Неизвестная роль пользователя! Попробуйте ещё раз.";
            else if (_context.Users.Select(member => member.Email).Contains(user.Email))
                ViewBag.Error = "В системе уже зарегистрирован пользователь с таким E-mail!";
            else if (user.Password.Length < 6 || user.Password.Length > 20)
                ViewBag.Error = "Длина пароля должна быть от 6 до 20 символов!";
            else
            {
                User DbUser = null;
                if (role == nameof(Expert))
                    DbUser = new Expert();
                else if (role == nameof(Admin))
                    DbUser = new Admin();
                DbUser.Update(user);
                DbUser.AdminId = Id;
                _context.Add(DbUser);
                _context.SaveChanges();
                ViewBag.Success = "Новый пользователь успешно зарегистрирован!";
            }
            return View();
        }

        #region Authentification
        private const string AUTHORIZED = "Authorized";
        private bool Authorized => HttpContext.Session.Keys.Contains(AUTHORIZED);
        private int? Id => HttpContext.Session.GetInt32("Id");
        private User AuthorizedUser => _context.Users.First(user => user.Id == Id && user.GetType().Name == HttpContext.Session.GetString(AUTHORIZED));

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
                HttpContext.Session.SetString(AUTHORIZED, user.GetType().Name /* user is Admin ? nameof(Admin) : nameof(Expert)*/);
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
            if (Authorized)
                ViewBag.User = AuthorizedUser;
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
