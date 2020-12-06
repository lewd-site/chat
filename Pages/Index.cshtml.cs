using Chat.Data;
using Chat.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ChatContext _context;

        public IList<Thread> Threads { get; set; }

        public IndexModel(ChatContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Threads = await _context.Threads.ToListAsync();
        }
    }
}
