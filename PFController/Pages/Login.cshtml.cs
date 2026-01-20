using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PFModel;
using PFServices;

namespace PFController.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("Received a post request.");
            Console.WriteLine("username: " + Request.Form["username"]);
            Console.WriteLine("Password: " + Request.Form["Password"]);

            User user = new User(Request.Form["username"], Request.Form["Password"]);

            Employee? employee = BaseServices.Login(user);


            if (employee == null) {
                Console.WriteLine("Login failed");
                return Page();
            }
            else
            {
                HttpContext.Response.Cookies.Append("user_id", employee.ID.ToString());
                Console.WriteLine("Login suceeded for "+employee.Name);
                return new RedirectToPageResult("/Profile");
            }

        }
    }
}
