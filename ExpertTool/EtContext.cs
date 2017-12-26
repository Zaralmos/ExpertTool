using ExpertTool.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool
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
    }
}
