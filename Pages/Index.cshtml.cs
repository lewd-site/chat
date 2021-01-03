using Chat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Chat.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ChatContext _context;

        public IndexModel(ChatContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var thread = _context.Threads.FirstOrDefault(thread => thread.IsDefault);
            if (thread == null)
            {
                return Page();
            }

            return Redirect($"/{thread.Slug}");
        }
    }
}
