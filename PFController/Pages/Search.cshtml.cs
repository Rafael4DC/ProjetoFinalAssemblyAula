using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PFModel;
using PFModel.Utils;
using PFServices;

namespace PFController.Pages
{
    public class SearchModel : PageModel
    {
        [BindProperty]
        public Filters filters { get; set; } = new Filters(); //Cuidado pode causar problemas com o trazer da informação

        [BindProperty]
        public List<Products> products { get; set; }

        [BindProperty]
        public List<Category> categories { get; set; }


        public void OnGet(string? Name)
        {
            filters.Name = Name ?? "";
            products = BaseServices.Search(filters);
            categories = BaseServices.GetCategories();

        }

        public object? Foo(string recipeId)
        {

            Console.WriteLine(recipeId);
            return null;
        }

        public IActionResult OnPost()
        {
            if (HttpContext.Request.Cookies["user_id"] == null)
                return new RedirectToPageResult("/Login");

            string emp = HttpContext.Request.Cookies["user_id"];
            string productId = Request.Form["product_id"];
            bool res = BaseServices.AddFavorite(productId, emp);


            Console.WriteLine(Request.GetEncodedPathAndQuery());


            var routeValues = Request.Query
            .ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.ToString()
            );
            return RedirectToPage(routeValues);
        }
    }
}
