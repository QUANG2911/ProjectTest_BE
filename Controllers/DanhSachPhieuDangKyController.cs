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
        private readonly IServiceContainer serviceContainer;

        public DanhSachPhieuDangKyController(IServiceContainer serviceContainer)
        {
            this.serviceContainer = serviceContainer;
        }

        [HttpGet("DanhSachPhieuNhap/{idUser}")]
        public async Task<IActionResult> DanhSachPhieuNhap(string idUser)
        {
            var danhSachPhieuNhap = await serviceContainer.GetDanhSachPhieuNhap(idUser);
            return Ok(danhSachPhieuNhap);
        }

        [HttpGet("ThongTinPhieuNhap/{maPhieuNhap}")]
        public IActionResult ThongTinPhieuNhap(string maPhieuNhap)
        {
            var thongTinPhieuNhapDto = serviceContainer.GetDetailPhieuNhap(maPhieuNhap);
            return Ok(thongTinPhieuNhapDto);
        }

        [HttpPut("CapNhatTrangThaiPhieuNhap/{maPhieuNhap}/{trangThai}")]
        public IActionResult CapNhatTrangThaiPhieuNhap(string maPhieuNhap, int trangThai)
        {
            var phieuNhap = serviceContainer.UpdatePhieuNhap(maPhieuNhap, trangThai);
            return Ok(phieuNhap);
        }

        [HttpPost("CreatePhieuDangKyNhap/{idUser}")]
        public IActionResult CreatePhieuDangKyNhap(string idUser, [FromBody] ContainerEntryFormDetailDto thongTinPhieuNhapDto)
        {
            ContainerEntryForm phieuNhap = serviceContainer.CreatePhieuNhap(idUser, thongTinPhieuNhapDto);
            return Ok(phieuNhap);
        }

    }
}
