using Chat.Models;
using System.Linq;

namespace Chat.Data
{
    public static class ChatSeeder
    {
        public static void Initialize(ChatContext context)
        {
            context.Database.EnsureCreated();

            if (context.Threads.Any())
            {
                return;
            }

            var threads = new Thread[] {
                new Thread{ Slug = "general", Title = "Основной", Icon = "home" },
                new Thread{ Slug = "po", Title = "Политика", Icon = "chat" },
            };

            context.Threads.AddRange(threads);
            context.SaveChanges();
        }
    }
}
