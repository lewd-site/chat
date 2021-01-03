using Chat.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostSection> PostSections { get; set; }
        public DbSet<PostSectionFile> PostSectionFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostSectionFile>().HasKey(p => new { p.PostSectionId, p.FileId });
            modelBuilder.Entity<PostReference>().HasKey(p => new { p.FromId, p.ToId });
        }
    }
}
