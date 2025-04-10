using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
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
            var result = _userService.LoginUser( new UserLoginDto() {
                Username = UserName,
                Password = Password
            });

            if (result.Status == OperationResultStatus.NotFound)
            {
                ModelState.AddModelError("UserName", "کاربر وجود ندارد");
                return Page();
            }
            return RedirectToPage("../Index");
            
        }

    }
}
