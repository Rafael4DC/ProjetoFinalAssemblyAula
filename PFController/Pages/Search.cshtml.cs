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


        public void OnGet(string searchText)
        {
            filters.Name = searchText;
            BaseServices.Search(filters);

        }
    }
}
