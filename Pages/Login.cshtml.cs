using Chat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Chat.Pages
{
    public class LoginViewModel
    {
        [Required, RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Only letters and digits allowed."), MaxLength(255)]
        public string Name { get; set; }

        [Required, DataType(DataType.Password), MinLength(8), MaxLength(255)]
        public string Password { get; set; }
    }

    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public LoginModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LoginViewModel Login { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(Login.Name, Login.Password, true, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
