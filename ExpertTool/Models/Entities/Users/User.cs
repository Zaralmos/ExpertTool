using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models
{
    public class User
    {
        public int Id { get; set; }

        /// <summary>
        /// Полное имя пользователя.
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Не указано ФИО")]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        /// <summary>
        /// Должность и место работы.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Краткое описание персоны в 3-4 предложения.
        /// </summary>
        [MaxLength(1000, ErrorMessage = "Слишком длинное описание")]
        public string ShortInfo { get; set; }

        /// <summary>
        /// Телефонный номер пользователя.
        /// </summary>
        [Phone(ErrorMessage = "Поле должно представлять номер телефона")]
        public string Phone { get; set; }

        /// <summary>
        /// E-mail пользователя, также используемй для входа в систему.
        /// </summary>
        [Required(ErrorMessage = "Не указан E-mail"), EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Пароль, исполььзуемый для входа в систему.
        /// </summary>
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Id админа, зарешистрировавшего данного пользователя.
        /// </summary>
        public int? AdminId { get; set; }
        /// <summary>
        /// Админ, который зарегистрировал данного пользователя.
        /// </summary>
        public Admin Admin { get; set; }
    }
}
