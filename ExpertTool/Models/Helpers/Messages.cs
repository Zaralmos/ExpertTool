using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models.Helpers
{
    public class Messages
    {
        public string Success { get; } = "Персональные данные сохранены.";

        public string Unknow { get; } = "Неизвестная роль пользователя! Попробуйте ещё раз.";

        public string Exist { get; } = "В системе уже зарегистрирован пользователь с таким E-mail!";

        public string UncorrectPassLen { get; } = "Длина пароля должна быть от 6 до 20 символов!";

        public string RegistSuc { get; } = "Новый пользователь успешно зарегистрирован!";

        public string RegistErr { get; } = "При регистрации призошла ошибка! Попробуйте ещё раз.";

        public string UserNotFound { get; } = "Сочетание E-mail и пароля не найдено. Попробуйте снова.";

    }
}
