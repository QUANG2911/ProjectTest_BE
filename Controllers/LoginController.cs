using Microsoft.AspNetCore.Mvc;
using ProjectTest.Interface;
using ProjectTest.Models;

namespace ProjectTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAccountService _Icontext;
        public LoginController(IAccountService icontext)
        {
            _Icontext = icontext;
        }

        [HttpGet("GetThongTinDangNhap/{userName}/{password}")]
        public ActionResult GetThongTinDangNhap(string userName, string password)
        {
            var taiKhoan = _Icontext.GetUserId(userName,password);

            return Ok(taiKhoan);
        }
    }
}
