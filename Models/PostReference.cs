using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
    public class PostReference
    {
        [Required]
        public int FromId { get; set; }
        public Post From { get; set; }

        [Required]
        public int ToId { get; set; }
        public Post To { get; set; }
    }
}
