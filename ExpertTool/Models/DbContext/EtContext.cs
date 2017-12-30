using ExpertTool.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models
{
    public class EtContext : DbContext
    {
        public EtContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Expert> Experts { get; set; }

        public DbSet<Conclusion> Conclusions { get; set; }

        public DbSet<Evaluation> Evaluations { get; set; }

        public DbSet<Person> People { get; set; }

        [NotMapped]
        public List<User> Users => (Admins as IEnumerable<User>).Union(Experts).ToList();
    }
}
