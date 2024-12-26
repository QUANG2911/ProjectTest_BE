using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Data;
using ProjectTest.DOTs;
using ProjectTest.DTOs;
using ProjectTest.Interface;
using ProjectTest.Models;

namespace test03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhSachPhieuXuatController : ControllerBase
    {
        private readonly IServiceContainer serviceContainer;

        public DanhSachPhieuXuatController(IServiceContainer serviceContainer)
        {
            this.serviceContainer = serviceContainer;
        }

        [HttpGet("DanhSachPhieuXuat/{idUser}")]
        public async Task<IActionResult> DanhSachPhieuXuat(string idUser)
        {
            var danhSachPhieuXuat = await serviceContainer.GetDanhSachPhieuXuatDtos(idUser);
            return Ok(danhSachPhieuXuat);
        }

        [HttpGet("DanhSachContainerXuat/{maphieu}")]
        public async Task<IActionResult> DanhSachContainerXuat(string maphieu)
        {
            var danhSachContainerXuat = await serviceContainer.GetDetailPhieuXuatDtos(maphieu);
            return Ok(danhSachContainerXuat);
        }

        [HttpPut("DuyetPhieuXuat/{maphieu}/{trangThaiDuyet}")]
        public IActionResult DuyetPhieuXuat(string maphieu, int trangThaiDuyet)
        {
            var danhSach = serviceContainer.UpdateTrangThaiPhieuXuat(maphieu, trangThaiDuyet);
            return Ok(danhSach);
        }

        [HttpGet("DsContainerCuaUserTrongCang{idUser}")]
        public async Task<IActionResult> DsContainerCuaUserTrongCang(string idUser)
        {
            var listContainerChuaXuat = await serviceContainer.GetDsContainerCuaUserTrongCang(idUser);
            return Ok(listContainerChuaXuat);
        }

        [HttpPost("PhieuXuat/{idUser}/{idContainer}")]
        public IActionResult CreatePhieuXuat(string idUser, string idContainer, [FromBody] ContainerExitFormDetailDto thongTinPhieuXuat)
        {
            var phieuXuat = serviceContainer.CreatePhieuXuat(idUser, idContainer, thongTinPhieuXuat);

            return Ok(phieuXuat);

        }
    }
}
