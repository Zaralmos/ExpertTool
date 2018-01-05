using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models.Helpers
{
    public static class Messages
    {
        public static string Success { get; } = "Персональные данные сохранены.";

        public static string Unknow { get; } = "Неизвестная роль пользователя! Попробуйте ещё раз.";

        public static string Exist { get; } = "В системе уже зарегистрирован пользователь с таким E-mail!";

        public static string UncorrectPassLen { get; } = "Длина пароля должна быть от 6 до 20 символов!";

        public static string RegistSuc { get; } = "Новый пользователь успешно зарегистрирован!";

        public static string RegistErr { get; } = "При регистрации призошла ошибка! Попробуйте ещё раз.";

        public static string UserNotFound { get; } = "Сочетание E-mail и пароля не найдено. Попробуйте снова.";

        public static string AdminsNotFound { get; } = "Админы в системе не найдены";

        public static string ExpertsNotFound { get; } = "Эксперты в системе не найдены";
    }
}
