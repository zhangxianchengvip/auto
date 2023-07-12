using Auto.Core.AutoDependencyInjection;

namespace Auto.Users
{
    [AutoService]
    public class User : IUser
    {
        public void Get()
        {
            Console.WriteLine(1);
        }
    }
}
