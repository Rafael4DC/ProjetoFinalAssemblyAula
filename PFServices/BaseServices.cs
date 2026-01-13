using PFModel;

namespace PFServices
{
    public class BaseServices
    {
        public static Employee? Login(User user)
        {
            return PFRepo.BaseRepo.Login(user);
        }
    }
}
