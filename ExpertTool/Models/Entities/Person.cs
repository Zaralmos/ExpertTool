using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        /// Краткое описание персоны в 3-4 предложения.
        /// </summary>
        [MaxLength(1000, ErrorMessage = "Слишком длинное описание")]
        public string ShortInfo { get; set; }

        #region Bio

        public string Photo { get; set; }

        public string Publish { get; set; }

        public string Video { get; set; }

        public string Biography { get; set; }

        public string Career { get; set; }

        public string ReligiousViews { get; set; }

        public string Quotations { get; set; }

        public string SocialActivity { get; set; }

        #endregion

        public int AdminId { get; set; }
        public virtual Admin Admin { get; set; }

        public virtual ICollection<Conclusion> Conclusions { get; set; } = new List<Conclusion>();

        public DateTime Published { get; set; }

        public void Update(Person source)
        {
            if (!string.IsNullOrWhiteSpace(source.Name))
                Name = source.Name;
            Birthday = source.Birthday;
            Position = source.Position;
            Photo = source.Photo;
            Publish = source.Publish;
            Video = source.Video;
            Biography = source.Biography;
            Career = source.Career;
            ReligiousViews = source.ReligiousViews;
            Quotations = source.Quotations;
            SocialActivity = source.SocialActivity;
        }
    }
}
