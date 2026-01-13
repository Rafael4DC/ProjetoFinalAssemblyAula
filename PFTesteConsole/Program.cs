using PFModel;

namespace PFTesteConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Teste 1");
            User user = new User();
            user.Username = Console.ReadLine();
            user.Password = Console.ReadLine();

            Employee emp = PFServices.BaseServices.Login(user);

            Console.WriteLine("Employee");
            Console.WriteLine(emp.ID);
            Console.WriteLine(emp.Name);

        }
    }
}
