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
        private readonly IServiceContainer _serviceContainer;

        public DanhSachPhieuXuatController(IServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
        }

        [HttpGet("DanhSachPhieuXuat/{idUser}")]
        public async Task<IActionResult> DanhSachPhieuXuat(string idUser)
        {
            var danhSachPhieuXuat = await _serviceContainer.GetContainerExitFormList(idUser);
            return Ok(danhSachPhieuXuat);
        }

        [HttpGet("DanhSachContainerXuat/{idExitForm}")]
        public async Task<IActionResult> DanhSachContainerXuat(string idExitForm)
        {
            var danhSachContainerXuat = await _serviceContainer.GetInformationContainerExitForm(idExitForm);
            return Ok(danhSachContainerXuat);
        }

        [HttpPut("DuyetPhieuXuat/{idExitForm}/{status}")]
        public IActionResult DuyetPhieuXuat(string idExitForm, int status)
        {
            var danhSach = _serviceContainer.UpdateStatusContainerExitForm(idExitForm, status);
            return Ok(danhSach);
        }

        [HttpGet("DsContainerCuaUserTrongCang{idUser}")]
        public async Task<IActionResult> DsContainerCuaUserTrongCang(string idUser)
        {
            var listContainerChuaXuat = await _serviceContainer.GetListContainerOfUserInSnp(idUser);
            return Ok(listContainerChuaXuat);
        }

        [HttpPost("PhieuXuat/{idUser}/{idContainer}")]
        public IActionResult CreatePhieuXuat(string idUser, string idContainer, [FromBody] ContainerExitFormDetailDto containerExitFormDetailDto)
        {
            var phieuXuat = _serviceContainer.CreateContainerExitForm(idUser, idContainer, containerExitFormDetailDto);

            return Ok(phieuXuat);

        }
    }
}
