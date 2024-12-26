using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.DOTs;
using ProjectTest.Interface;
using ProjectTest.Models;


namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhSachPhieuDangKyController : ControllerBase
    {
        private readonly I_ServiceContainer _Icontext;

        public DanhSachPhieuDangKyController(I_ServiceContainer Icontext)
        {
            _Icontext = Icontext;
        }

        [HttpGet("DanhSachPhieuNhap/{idUser}")]
        public async Task<IActionResult> DanhSachPhieuNhap(string idUser)
        {
            var danhSachPhieuNhap = await _Icontext.GetDanhSachPhieuNhap(idUser);
            return Ok(danhSachPhieuNhap);
        }

        [HttpGet("ThongTinPhieuNhap/{maPhieuNhap}")]
        public IActionResult ThongTinPhieuNhap(string maPhieuNhap)
        {
            var thongTinPhieuNhapDto = _Icontext.GetDetailPhieuNhap(maPhieuNhap);
            return Ok(thongTinPhieuNhapDto);
        }

        [HttpPut("CapNhatTrangThaiPhieuNhap/{maPhieuNhap}/{trangThai}")]
        public IActionResult CapNhatTrangThaiPhieuNhap(string maPhieuNhap, int trangThai)
        {
            var phieuNhap = _Icontext.UpdatePhieuNhap(maPhieuNhap, trangThai);
            return Ok(phieuNhap);
        }

        [HttpPost("CreatePhieuDangKyNhap/{idUser}")]
        public IActionResult CreatePhieuDangKyNhap(string idUser, [FromBody] ThongTinPhieuNhapDto thongTinPhieuNhapDto)
        {
            PhieuNhap phieuNhap = _Icontext.CreatePhieuNhap(idUser, thongTinPhieuNhapDto);
            return Ok(phieuNhap);
        }

    }
}
