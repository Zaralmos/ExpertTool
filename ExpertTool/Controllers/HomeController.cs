using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExpertTool.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ExpertTool.Controllers
{
    public class HomeController : Controller
    {
        public EtContext _context { get; set; }

        public HomeController(EtContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Представляет главную страницу со списком персон, по которым необходимо получить экспертные оценки.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.People = _context.People;
            return View();
        }

        /// <summary>
        /// Представляет профиль пользователя, даёт доступ в его личный кабинет
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        /// <summary>
        /// Служит для обновления персональных данных через личный кабинет.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Profile(User user)
        {
            AuthorizedUser.Update(user);
            _context.SaveChanges();
            ViewBag.Success = "Персональные данные сохранены.";
            ViewBag.User = AuthorizedUser;
            return View();
        }

        /// <summary>
        /// Представляет информацию о проекте "Экспертный инструмент"
        /// </summary>
        /// <returns></returns>
        public IActionResult About()
        {
            return View();
        }

        /// <summary>
        /// Представляет раздел помощи по работе с проектом, даёт инструкции по выполнению действий при помощи системы.
        /// </summary>
        /// <returns></returns>
        public IActionResult Help()
        {
            return View();
        }

        /// <summary>
        /// Предоставляет администратору возможность регистрации новых пользователей.
        /// </summary>
        /// <param name="role">Название роли нового пользователя (<see cref="Expert"/>, <see cref="Admin"/>)</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register(string role)
        {
            ViewBag.role = role;
            return View();
        }

        /// <summary>
        /// Служит для получения информации о новом пользователе и внесении его в базу данных.
        /// </summary>
        /// <param name="user">Информация о новом пользователе.</param>
        /// <param name="role">Название роли нового пользователя (<see cref="Expert"/>, <see cref="Admin"/>)</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(User user, string role)
        {
            ViewBag.RegisteredUser = user;
            try
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
                    ViewBag.RegisteredUser = DbUser;
                    ViewBag.Success = "Новый пользователь успешно зарегистрирован!";
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "При регистрации призошла ошибка! Попробуйте ещё раз.";
            }
            return View();
        }

        /// <summary>
        /// Представляет администратору список всех пользователей, зарегистрированныъх в системе.
        /// </summary>
        /// <returns></returns>
        public IActionResult Users()
        {
            IActionResult result = null;
            if (AuthorizedUser is Admin)
            {
                ViewBag.Admins = _context.Admins;
                ViewBag.Experts = _context.Experts;
                result = View();
            }
            else
                result = Forbid();
            return result;
        }

        [HttpGet]
        public IActionResult Person(int? id)
        {
            if (id != null)
            {
                ViewBag.Person = _context.People.Find(id);
                if (AuthorizedUser is Expert)
                    ViewBag.Conclusion = _context.Conclusions.FirstOrDefault(cion => cion.PersonId == id && cion.ExpertId == Id);
                else
                {
                    IEnumerable<Conclusion> conclusions = _context.Conclusions.Where(conclusion => conclusion.PersonId == id);
                    if (conclusions != null && conclusions.Count() > 0)
                    {
                        IEnumerable<byte> summary = new byte[10]; // Шо-то извращение какое-то. Если не лень, люди добрые, переделайте кусок кода, плз!..
                        foreach (Conclusion conclusion in conclusions)
                            summary = summary.Zip(conclusion.Values, (a, b) => (byte)(a + b));
                        ViewBag.Scales = summary.Select(evaluation => evaluation / conclusions.Count()).ToList();
                        ViewBag.Conclusions = conclusions;
                    }
                    else
                        ViewBag.Error = $"В системе нет ни одной экспертной оценки для персоны {ViewBag.Person?.Name}!";
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Person(Person person, int? id)
        {
            if (id != null)
            {
                _context.People.Find(id)?.Update(person);
            }
            else
            {
                person.AdminId = Id ?? 0;
                person.Published = DateTime.Now;
                _context.People.Add(person);

                int i = _context.People.Count();
            }
            _context.SaveChanges();
            //ViewBag.Success = "Изменения успешно сохранены";
            //ViewBag.Person = person;
            string stringId = id == null ? string.Empty : id.ToString();
            return Redirect($"~/Home/Person/{stringId}");
        }

        [HttpPost]
        public IActionResult EvaluatePerson(Conclusion conclusion, int? id)
        {
            conclusion.Id = 0;
            Conclusion DbConclusion = null;
            if (id != null)
                DbConclusion = _context.Conclusions.FirstOrDefault(cion => cion.PersonId == id && cion.ExpertId == Id);
            if (DbConclusion == null)
            {
                DbConclusion = conclusion;
                DbConclusion.ExpertId = Id??0;
                DbConclusion.PersonId = id??0;
                DbConclusion.Update(conclusion);
                _context.Conclusions.Add(DbConclusion);
            }
            else
            {
                DbConclusion.Update(conclusion);
            }
            _context.SaveChanges();
            string stringId = id == null ? string.Empty : id.ToString();
            return Redirect($"~/Home/Person/{stringId}");
        }

        #region Authentification
        private const string AUTHORIZED = "Authorized";

        /// <summary>
        /// Показывает, авторизован ли в системе пользователь, осуществляющий запрос.
        /// </summary>
        private bool Authorized => HttpContext.Session.Keys.Contains(AUTHORIZED);
        private int? Id => HttpContext.Session.GetInt32("Id");
        private User AuthorizedUser => _context.Users.First(user => user.Id == Id && user.GetType().Name == HttpContext.Session.GetString(AUTHORIZED));

        public EntityState Modified { get; private set; }

        /// <summary>
        /// Предоставляет доступ к странице авторизации
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Принимает данные, отправленные пользователем для авторизации в системе.
        /// </summary>
        /// <param name="email">E-mail пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Обеспечивает пользователю возможность выйти из системы принудительно.
        /// </summary>
        /// <returns></returns>
        public IActionResult DeAuth()
        {
            if (Authorized)
                HttpContext.Session.Remove(AUTHORIZED);
            return LocalRedirect("~/Home/Auth");
        }

        /// <summary>
        /// Переопределённый метод проверки входящего запроса, позволяющий убедится, что клиент авторизован в системе.
        /// </summary>
        /// <param name="context"></param>
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
