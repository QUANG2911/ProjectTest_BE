using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.DOTs;
using ProjectTest.Interface;
using ProjectTest.Models;


namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryContainerFormManagementController : ControllerBase
    {
        private readonly IServiceContainer _serviceContainer;

        public EntryContainerFormManagementController(IServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
        }

        [HttpGet("GetContainerEntryFormList/{idUser}")]
        public async Task<IActionResult> GetContainerEntryFormList(string idUser)
        {
            var entryContainerFormList = await _serviceContainer.GetContainerEntryFormList(idUser);
            return Ok(entryContainerFormList);
        }

        [HttpGet("GetInformationContainerEntryForm/{idEntryForm}")]
        public IActionResult GetInformationContainerEntryForm(string idEntryForm)
        {
            var informationContainerEntryForm = _serviceContainer.GetInformationContainerEntryForm(idEntryForm);
            return Ok(informationContainerEntryForm);
        }

        [HttpPut("UpdateStatusContainerEntryForm/{idEntryForm}/{status}")]
        public IActionResult UpdateStatusContainerEntryForm(string idEntryForm, int status)
        {
            var entryContainerForm = _serviceContainer.UpdateStatusContainerEntryForm(idEntryForm, status);
            return Ok(entryContainerForm);
        }

        [HttpPost("CreateContainerEntryForm/{idUser}")]
        public IActionResult CreateContainerEntryForm(string idUser, [FromBody] ContainerEntryFormDetailDto containerEntryFormDetailDto)
        {
            ContainerEntryForm entryContainerForm = _serviceContainer.CreateContainerEntryForm(idUser, containerEntryFormDetailDto);
            return Ok(entryContainerForm);
        }

    }
}
