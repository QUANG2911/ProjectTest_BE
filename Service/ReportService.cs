using ProjectTest.Data;
using ProjectTest.Interface;
using ProjectTest.Models;

namespace ProjectTest.Service
{
    public class ReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateNewReport(string userId, string noidung)
        {
            var report = new Report
            {
                USERID = userId,
                NOIDUNG = noidung,
                THOIGIANQUERY = DateTime.Now,
            };

            _context.Reports.Add(report);
            _context.SaveChanges();
        }
    }
}
