using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Models
{
    public class File
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Extension { get; set; }

        [Required, MaxLength(255)]
        public string MimeType { get; set; }

        [Required, MaxLength(255)]
        public string Md5 { get; set; }

        [Required]
        public int Size { get; set; }

        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [Required, Column(TypeName = "jsonb")]
        public string Meta { get; set; }
    }
}
