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

        string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Position { get; set; }

        public string Biography { get; set; }

        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        public virtual ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();
    }
}
