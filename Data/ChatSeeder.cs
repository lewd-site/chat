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

            var now = DateTimeOffset.UtcNow;

            if (!context.Users.Any())
            {
                var users = new User[] {
                    new User {
                        Name = "Anonymous",
                        Email = "test@example.com",
                        EmailConfirmed = true,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("password", 10),
                        CreatedAt = now,
                    },
                };

                context.Users.AddRange(users);
            }

            if (!context.Threads.Any())
            {
                var threads = new Thread[] {
                    new Thread { Slug = "general", Title = "Основной", Icon = "sidebar-general" },
                    new Thread { Slug = "po", Title = "Политика", Icon = "sidebar-po" },
                };

                context.Threads.AddRange(threads);
            }

            context.SaveChanges();

            if (!context.Posts.Any())
            {
                var posts = new Post[] {
                    new Post {
                        Name = "Anonymous",
                        Tripcode = "#mdUF",
                        ThreadId = 1,
                        UserId = 1,
                        CreatedAt = now,
                        UpdatedAt = now,
                    },
                    new Post {
                        Name = "Anonymous",
                        Tripcode = "#mdUF",
                        ThreadId = 1,
                        UserId = 1,
                        CreatedAt = now,
                        UpdatedAt = now,
                    },
                    new Post {
                        Name = "Anonymous",
                        Tripcode = "#mdUF",
                        ThreadId = 1,
                        UserId = 1,
                        CreatedAt = now,
                        UpdatedAt = now,
                    },
                };

                context.Posts.AddRange(posts);
            }

            context.SaveChanges();

            if (!context.PostSections.Any())
            {
                var sections = new PostSection[] {
                    new PostSection {
                        MarkupType = "none",
                        Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                        PostId = 1,
                        UserId = 1,
                        CreatedAt = now,
                    },
                    new PostSection {
                        MarkupType = "none",
                        Message = "Ut enim ad minim veniam",
                        PostId = 2,
                        UserId = 1,
                        CreatedAt = now,
                    },
                    new PostSection {
                        MarkupType = "none",
                        Message = "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                        PostId = 3,
                        UserId = 1,
                        CreatedAt = now,
                    },
                };

                context.PostSections.AddRange(sections);
            }

            context.SaveChanges();
        }
    }
}
