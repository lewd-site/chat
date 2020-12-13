using Chat.Models;
using System;
using System.Linq;

namespace Chat.Data
{
    public static class ChatSeeder
    {
        public static void Initialize(ChatContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Threads.Any())
            {
                var threads = new Thread[] {
                    new Thread{ Slug = "general", Title = "Основной", Icon = "home" },
                    new Thread{ Slug = "po", Title = "Политика", Icon = "chat" },
                };

                context.Threads.AddRange(threads);
            }

            if (!context.Users.Any())
            {
                var users = new User[] {
                    new User{
                        Name = "Anonymous",
                        Email = "test@example.com",
                        EmailConfirmed = true,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("password", 10),
                        CreatedAt = DateTimeOffset.UtcNow,
                    },
                };

                context.Users.AddRange(users);
            }

            context.SaveChanges();
        }
    }
}
