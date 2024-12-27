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
            var danhSachPhieuNhap = await _serviceContainer.GetContainerEntryFormList(idUser);
            return Ok(danhSachPhieuNhap);
        }

        [HttpGet("ThongTinPhieuNhap/{idEntryForm}")]
        public IActionResult ThongTinPhieuNhap(string idEntryForm)
        {
            var thongTinPhieuNhapDto = _serviceContainer.GetInformationContainerEntryForm(idEntryForm);
            return Ok(thongTinPhieuNhapDto);
        }

        [HttpPut("CapNhatTrangThaiPhieuNhap/{idEntryForm}/{status}")]
        public IActionResult CapNhatTrangThaiPhieuNhap(string idEntryForm, int status)
        {
            var phieuNhap = _serviceContainer.UpdateStatusContainerEntryForm(idEntryForm, status);
            return Ok(phieuNhap);
        }

        [HttpPost("CreatePhieuDangKyNhap/{idUser}")]
        public IActionResult CreatePhieuDangKyNhap(string idUser, [FromBody] ContainerEntryFormDetailDto containerEntryFormDetailDto)
        {
            ContainerEntryForm phieuNhap = _serviceContainer.CreateContainerEntryForm(idUser, containerEntryFormDetailDto);
            return Ok(phieuNhap);
        }

    }
}
