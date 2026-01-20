using PFModel;
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
    }
}
