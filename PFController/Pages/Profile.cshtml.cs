using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PFModel;
using PFServices;

namespace PFController.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly ILogger<ProfileModel> _logger;
        internal Employee emp;

        public ProfileModel(ILogger<ProfileModel> logger)
        {
            _logger = logger;
            emp = new Employee();
        }

        public IActionResult OnGet()
        {
            if(HttpContext.Request.Cookies["user_id"]==null)
                return new RedirectToPageResult("/Login");

            emp = BaseServices.getEmployee(HttpContext.Request.Cookies["user_id"]);
            return Page();
        }
    }

}
