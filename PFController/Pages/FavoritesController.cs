using Microsoft.AspNetCore.Mvc;
using PFServices;

namespace PFController.Pages
{
    public class FavoritesController : Controller
    {
        public IActionResult Add(string productId)
        {
            if (HttpContext.Request.Cookies["user_id"] == null)
                return new RedirectToPageResult("/Login");

            string emp = HttpContext.Request.Cookies["user_id"];
            bool res = BaseServices.AddFavorite(productId, emp);
            return View();
        }
    }
}
