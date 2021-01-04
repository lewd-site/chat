using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
    public class PostSection
    {
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }
        public Post Post { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required, MaxLength(255)]
        public string MarkupType { get; set; }

        [Required, MaxLength(8000)]
        public string Message { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        public List<PostSectionFile> PostSectionFiles { get; set; }
    }
}
