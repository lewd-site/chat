using System;
using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        [Required, MaxLength(255)]
        public string PasswordHash { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
