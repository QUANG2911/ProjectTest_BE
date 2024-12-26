using ProjectTest.Data;
using ProjectTest.Interface;
using ProjectTest.Models;

namespace ProjectTest.Service
{
    public class AccountService: IAccountService
    {
        private ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserAccount GetUserId(string userName, string password)
        {
            var taiKhoan = _context.taiKhoans.Where(p=>p.Pass == password && p.UserName == userName).FirstOrDefault();

            if (taiKhoan == null)
            {
                throw new Exception("tài khoản không toàn tại");
            }
            return taiKhoan;
        }
    }
}
