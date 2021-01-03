using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
    public class PostSectionFile
    {
        [Required]
        public int PostSectionId { get; set; }
        public PostSection PostSection { get; set; }

        [Required]
        public int FileId { get; set; }
        public File File { get; set; }
    }
}
