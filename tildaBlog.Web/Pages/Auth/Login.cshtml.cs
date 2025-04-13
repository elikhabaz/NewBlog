using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using tildaBlog.CoreLayer.Services.DTOs.Users;
using tildaBlog.CoreLayer.Services.Users;
using tildaBlog.CoreLayer.Utilities;

namespace tildaBlog.Web.Pages.Auth
{
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        #region
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Password { get; set; }
        #endregion
        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }
        public ModelStateDictionary GetModelState()
        {
            return ModelState;
        }

        public IActionResult OnPost()
        {
            var user = _userService.LoginUser( new UserLoginDto() {
                Username = UserName,
                Password = Password
            });

            if (user==null)
            {
                ModelState.AddModelError("UserName", "کاربر وجود ندارد");
                return Page();
            }
            //I want login the User in our system
            List<Claim> claims = new List<Claim>() { 
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.Fullname),
            };
            var identity = new ClaimsIdentity(claims , CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrinciple = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties() { 
                IsPersistent = true
            };
            HttpContext.SignInAsync(claimPrinciple);
            return RedirectToPage("../Index");
            
        }

    }
}
