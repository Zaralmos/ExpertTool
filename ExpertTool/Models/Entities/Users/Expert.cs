using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models
{
    /// <summary>
    /// Представляет класс эксперта.
    /// </summary>
    public class Expert : User
    {
        /// <summary>
        /// Оценки, выставленная экспертом.
        /// </summary>
        public virtual ICollection<Conclusion> Conclusions { get; set; } = new List<Conclusion>();
    }
}
