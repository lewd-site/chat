using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public int ThreadId { get; set; }
        public Thread Thread { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Tripcode { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        public DateTimeOffset UpdatedAt { get; set; }

        public List<PostSection> PostSections { get; set; } = new List<PostSection>();
    }
}
