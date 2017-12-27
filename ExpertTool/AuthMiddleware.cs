using ExpertTool.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpertTool
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly EtContext _context;
        public AuthMiddleware(RequestDelegate next, EtContext context)
        {
            _next = next;
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Session.Keys.Contains("Authorized"))
            {
                IFormCollection form = context.Request.Form;
                if (form.Keys.Contains("Password") && form.Keys.Contains("Email"))
                {
                    User user = FindUser(form["Password"], form["Email"]);
                    if (user != null)
                        context.Session.SetString("Authorized", "True");
                    else
                        await context.Response.WriteAsync("Неверные данные!");
                }                
            }
            if (context.Session.Keys.Contains("Authorized"))
            {
                await _next(context);
            }
        }

        private User FindUser(string Email, string Password) => 
            _context.Experts.FirstOrDefault(expert => expert.Email == Email) as User
                ?? _context.Admins.FirstOrDefault(admin => admin.Email == Email);
    }
}