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
    public class ExitContainerFormManagementController : ControllerBase
    {
        private readonly IServiceContainer _serviceContainer;

        public ExitContainerFormManagementController(IServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
        }

        [HttpGet("GetContainerExitFormList/{idUser}")]
        public async Task<IActionResult> GetContainerExitFormList(string idUser)
        {
            var exitContainerFormList = await _serviceContainer.GetContainerExitFormList(idUser);
            return Ok(exitContainerFormList);
        }

        [HttpGet("GetInformationContainerExitForm/{idExitForm}")]
        public async Task<IActionResult> GetInformationContainerExitForm(string idExitForm)
        {
            var exitInformationContainerForm = await _serviceContainer.GetInformationContainerExitForm(idExitForm);
            return Ok(exitInformationContainerForm);
        }

        [HttpPut("UpdateStatusContainerExitForm/{idExitForm}/{status}")]
        public IActionResult UpdateStatusContainerExitForm(string idExitForm, int status)
        {
            var ContainerExitForm = _serviceContainer.UpdateStatusContainerExitForm(idExitForm, status);
            return Ok(ContainerExitForm);
        }

        [HttpGet("GetListContainerOfUserInSnp/{idUser}")]
        public async Task<IActionResult> GetListContainerOfUserInSnp(string idUser)
        {
            var ListContainerOfUserInSnp = await _serviceContainer.GetListContainerOfUserInSnp(idUser);
            return Ok(ListContainerOfUserInSnp);
        }

        [HttpPost("CreateContainerExitForm/{idUser}/{idContainer}")]
        public IActionResult CreateContainerExitForm(string idUser, string idContainer, [FromBody] ContainerExitFormDetailDto containerExitFormDetailDto)
        {
            var containerExitForm = _serviceContainer.CreateContainerExitForm(idUser, idContainer, containerExitFormDetailDto);

            return Ok(containerExitForm);

        }
    }
}
