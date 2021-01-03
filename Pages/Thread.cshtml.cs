using Chat.Data;
using Chat.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Pages
{
    public class ThreadModel : PageModel
    {
        private readonly ChatContext _context;

        public Thread Thread { get; set; }
        public List<Post> Posts { get; set; }

        public ThreadModel(ChatContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(string slug)
        {
            Thread = await _context.Threads.FirstOrDefaultAsync(thread => thread.Slug == slug);

            if (Thread == null)
            {
                return NotFound();
            }

            Posts = Thread.Posts;

            return Page();
        }
    }
}
