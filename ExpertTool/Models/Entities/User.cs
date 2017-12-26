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

        [Required(AllowEmptyStrings = false, ErrorMessage = "Не указано ФИО")]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        /// <summary>
        /// Должность и место работы.
        /// </summary>
        public string Position { get; set; }

        [Required(ErrorMessage = "Не указан E-mail"), EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Телефонный номер пользователя.
        /// </summary>
        public string Phone { get; set; }

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
