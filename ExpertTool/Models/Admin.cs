﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models
{
    /// <summary>
    /// Представляет класс админа.
    /// </summary>
    public class Admin
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        /// <summary>
        /// Должность и место работы админа.
        /// </summary>
        public string Position { get; set; }

        public virtual ICollection<Person> People { get; set; } = new List<Person>();
    }
}