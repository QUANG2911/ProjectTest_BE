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
        private readonly IServiceContainer _serviceContainer;

        public DanhSachPhieuDangKyController(IServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
        }

        [HttpGet("DanhSachPhieuNhap/{idUser}")]
        public async Task<IActionResult> DanhSachPhieuNhap(string idUser)
        {
            var danhSachPhieuNhap = await _serviceContainer.GetDanhSachPhieuNhap(idUser);
            return Ok(danhSachPhieuNhap);
        }

        [HttpGet("ThongTinPhieuNhap/{maPhieuNhap}")]
        public IActionResult ThongTinPhieuNhap(string maPhieuNhap)
        {
            var thongTinPhieuNhapDto = _serviceContainer.GetDetailPhieuNhap(maPhieuNhap);
            return Ok(thongTinPhieuNhapDto);
        }

        [HttpPut("CapNhatTrangThaiPhieuNhap/{maPhieuNhap}/{trangThai}")]
        public IActionResult CapNhatTrangThaiPhieuNhap(string maPhieuNhap, int trangThai)
        {
            var phieuNhap = _serviceContainer.UpdatePhieuNhap(maPhieuNhap, trangThai);
            return Ok(phieuNhap);
        }

        [HttpPost("CreatePhieuDangKyNhap/{idUser}")]
        public IActionResult CreatePhieuDangKyNhap(string idUser, [FromBody] ContainerEntryFormDetailDto thongTinPhieuNhapDto)
        {
            ContainerEntryForm phieuNhap = _serviceContainer.CreatePhieuNhap(idUser, thongTinPhieuNhapDto);
            return Ok(phieuNhap);
        }

    }
}
