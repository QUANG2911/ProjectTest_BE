using ProjectTest.Models;

namespace ProjectTest.Interface
{
    public interface IAccountService
    {
        UserAccount GetUserId(string userName, string password);
    }
}
