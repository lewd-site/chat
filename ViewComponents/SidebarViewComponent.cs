using Chat.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Chat.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly ChatContext _context;

        public SidebarViewComponent(ChatContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.Threads.ToListAsync();

            return View(items);
        }
    }
}
