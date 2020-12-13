using Chat.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Chat.Pages
{
    public class RegisterViewModel
    {
        [Required, RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Only letters and digits allowed."), MaxLength(255)]
        public string Name { get; set; }

        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password), MinLength(8), MaxLength(255)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), MinLength(8), MaxLength(255), Compare(nameof(Password), ErrorMessage = "Passwords doesn't match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public RegisterModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RegisterViewModel Register { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new User
            {
                Name = Register.Name,
                Email = Register.Email,
                EmailConfirmed = false,
                CreatedAt = DateTimeOffset.Now,
            };

            var result = await _userManager.CreateAsync(user, Register.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
