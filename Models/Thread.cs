﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
    public class Thread
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Slug { get; set; }

        [Required, MaxLength(255)]
        public string Title { get; set; }

        [Required, MaxLength(255)]
        public string Icon { get; set; }

        [Required]
        public bool IsDefault { get; set; }

        public List<Post> Posts { get; set; }
    }
}
