using Microsoft.AspNetCore.Mvc;
using ProjectTest.Interface;
using ProjectTest.Models;

namespace ProjectTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("GetThongTinDangNhap/{userName}/{password}")]
        public ActionResult GetThongTinDangNhap(string userName, string password)
        {
            var account = _accountService.GetUserId(userName,password);

            return Ok(account);
        }
    }
}
