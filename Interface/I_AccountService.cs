using ProjectTest.Models;

namespace ProjectTest.Interface
{
    public interface I_AccountService
    {
        TaiKhoan GetUserId(string userName, string password);
    }
}
