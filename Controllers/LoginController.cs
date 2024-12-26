using Microsoft.AspNetCore.Mvc;
using ProjectTest.Interface;
using ProjectTest.Models;

namespace ProjectTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccountService accountService;
        public LoginController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet("GetThongTinDangNhap/{userName}/{password}")]
        public ActionResult GetThongTinDangNhap(string userName, string password)
        {
            var taiKhoan = accountService.GetUserId(userName,password);

            return Ok(taiKhoan);
        }
    }
}
