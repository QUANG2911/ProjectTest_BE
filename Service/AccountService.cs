using ProjectTest.Data;
using ProjectTest.Interface;
using ProjectTest.Models;

namespace ProjectTest.Service
{
    public class AccountService: I_AccountService
    {
        private ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public TaiKhoan GetUserId(string userName, string password)
        {
            var taiKhoan = _context.taiKhoans.Where(p=>p.PASS == password && p.USERNAME == userName).FirstOrDefault();

            if (taiKhoan == null)
            {
                throw new Exception("tài khoản không toàn tại");
            }
            return taiKhoan;
        }
    }
}
