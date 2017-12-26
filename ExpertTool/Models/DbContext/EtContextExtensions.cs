using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool.Models
{
    public static class EtContextExtensions
    {
        public static EtContext Initialize(this EtContext context)
        {
            if (!context.Admins.Any())
            {
                context.Admins.Add(
                    new Models.Admin
                    {
                        Name = "Иванов Иван Иванович",
                        Birthday = DateTime.Now,
                        Position = "Главный аналитик Сокращённой MMPI",
                        Email = "admin@email.io",
                        Password = "admin",
                    });
            }
            return context;
        }
    }
}
