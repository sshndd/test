using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using RazorWeb.Models;

namespace RazorWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Email обязателен для заполнения.")]
            [EmailAddress(ErrorMessage = "Некорректный формат email.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Пароль обязателен для заполнения.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public bool RememberMe { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                else if (result.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Аккаунт заблокирован.");
                }
                else if (result.IsNotAllowed)
                {
                    ModelState.AddModelError(string.Empty, "Вход не разрешен.");
                }
                else if (result.RequiresTwoFactor)
                {
                    ModelState.AddModelError(string.Empty, "Требуется двухфакторная аутентификация.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверный email или пароль.");
                }
            }

            return Page();
        }
    }
}
