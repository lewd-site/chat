using Chat.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options) { }

        public DbSet<Thread> Threads { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
