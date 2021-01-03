using Chat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Chat.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ChatContext _context;

        public IndexModel(ChatContext context)
        {
            _context = context;
        }

        public IActionResult OnGetAsync()
        {
            return Page();
        }
    }
}
