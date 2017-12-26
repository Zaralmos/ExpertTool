using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models
{
    /// <summary>
    /// Представляет класс админа.
    /// </summary>
    public class Admin : User
    {
        /// <summary>
        /// Персоны, вынесенные на рассмотрение экспертов данным админом.
        /// </summary>
        public virtual ICollection<Person> People { get; set; } = new List<Person>();

        /// <summary>
        /// Список экспертов, зарегистрированных данным админом.
        /// </summary>
        public virtual ICollection<Expert> Experts { get; set; } = new List<Expert>();
    }
}
