using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models
{
    /// <summary>
    /// Представляет класс эксперта.
    /// </summary>
    public class Expert
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        /// <summary>
        /// Должность и место работы эксперта.
        /// </summary>
        public string Position { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// Оценки, выставленная экспертом.
        /// </summary>
        public virtual ICollection<Conclusion> Conclusions { get; set; } = new List<Conclusion>();

        /// <summary>
        /// Id админа, зарешистрировавшего данного эксперта.
        /// </summary>
        public int AdminId { get; set; }
        /// <summary>
        /// Админ, который зарегистрировал данного эксперта.
        /// </summary>
        public Admin Admin { get; set; }
    }
}
