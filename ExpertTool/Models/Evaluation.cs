using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models
{
    /// <summary>
    /// Представляет класс оценки экспертом персоны по системе упрощённой MMPI экспертом.
    /// </summary>
    public class Evaluation
    {
        public int Id { get; set; }

        public byte Hypochondriasis { get; set; }
        public byte Depression { get; set; }
        public byte Hysteria { get; set; }
        public byte PsychopathicDeviate { get; set; }
        public byte MaculinityFeminity { get; set; }
        public byte Paranoia { get; set; }
        public byte Psychasthenia { get; set; }
        public byte Schizophrenia { get; set; }
        public byte Hypomania { get; set; }
        public byte Socialbyteroversion { get; set; }

        public string Comment { get; set; }

        /// <summary>
        /// Id персоны, в отношении которой сформирована оценка.пше
        /// </summary>
        public int PersonId { get; set; }
        /// <summary>
        /// Персона, в отношении которой сформирована оценка.
        /// /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Id эксперта, сформировавшего оценку.
        /// </summary>
        public int ExpertId { get; set; }
        /// Эксперт, сформировавший оценку.
        public virtual Expert Expert { get; set; }
    }
}
