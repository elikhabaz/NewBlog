using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using tildaBlog.CoreLayer.Services.DTOs.Users;
using tildaBlog.CoreLayer.Services.Users;
using tildaBlog.CoreLayer.Utilities;

namespace tildaBlog.Web.Pages.Auth
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IUserService _userService;

        #region
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage ="{0} را وارد کنید")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Password { get; set; }
        #endregion


        public RegisterModel(IUserService userService) 
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

        public IActionResult OnPost(ModelStateDictionary modelState)
        {
            var result = _userService.RegisterUser(new UserRegisterDto() { 
                Username = UserName,
                Password = Password,
                Fullname = FullName
            });

            if (result.Status == OperationResultStatus.Error) {
                ModelState.AddModelError("UserName", result.Message);
                return Page();
            }
            return RedirectToPage("Login");
        }
    }
}
