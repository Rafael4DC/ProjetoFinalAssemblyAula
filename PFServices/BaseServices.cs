using Microsoft.IdentityModel.Tokens;
using PFModel;
using PFModel.Utils;
using PFRepo;

namespace PFServices
{
    public class BaseServices
    {
        public static Employee getEmployee(string? userId)
        {
            if (userId == null) throw new ArgumentNullException("User id was null");
            return BaseRepo.GetEmployee(userId);
        }

        public static Employee? Login(User user)
        {
            return PFRepo.BaseRepo.Login(user);
        }

        public static List<Products> Search(Filters filters, int skip = 0, int limit = 10)
        {
            if (filters.Name == "") return new List<Products>();

            List<Products> products = BaseRepo.GetProducts(skip,limit);
            List<Category> categories = BaseRepo.GetCategories();

            List<string> categoryIds = categories
                .Where(c => filters.Categories.Contains(c.Name))
                .Select(c => c.ID)
                .ToList();

            products = products
                .Where(product => 
                        product.Name.Contains(filters.Name) && //Filter by name
                        product.UnitPrice > filters.PriceMin && product.UnitPrice < filters.PriceMax && //Filter by price
                        ((product.UnitsInStock > 0 && filters.HasStock) || (!filters.HasStock)) && //Filter by Stock
                        (filters.Categories.IsNullOrEmpty() || categoryIds.Contains(product.Category.ID))) //Filter by categories
                .ToList();

            return products;
            
        }
    }
}
