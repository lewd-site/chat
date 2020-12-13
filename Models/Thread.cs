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
    }
}
