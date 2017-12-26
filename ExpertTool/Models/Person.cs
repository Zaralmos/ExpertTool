using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models
{
    /// <summary>
    /// Представляет класс персоны, вынесенной админом на оценку экспертам. 
    /// </summary>
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        /// <summary>
        /// Должность персоны.
        /// </summary>
        public string Position { get; set; }

        public string Biography { get; set; }

        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        public virtual ICollection<Conclusion> Conclusions { get; set; } = new List<Conclusion>();
    }
}
