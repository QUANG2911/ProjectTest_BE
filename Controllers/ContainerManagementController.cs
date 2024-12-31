
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data;
using ProjectTest.DOTs;
using System.ComponentModel.Design;
using ProjectTest.Service;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Interface;
namespace ProjectTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerManagementController : ControllerBase
    {
        private readonly Interface.IServiceContainer _serviceContainer;

        public ContainerManagementController(Interface.IServiceContainer serviceContainer)
        {
            _serviceContainer = serviceContainer;
        }

        [HttpGet("GetContainerList")]
        public async Task<ActionResult> GetContainerList()
        {
            var listContainers = await _serviceContainer.GetContainerListAsync();
            return Ok(listContainers);
        }


        [HttpGet("GetInformationContainer/{id}/{dateOfEntryContainer}")]
        public ActionResult GetInformationContainer(int id, DateTime dateOfEntryContainer)
        {
            var detailContainer = _serviceContainer.GetInformationContainer(id, dateOfEntryContainer);
            return Ok(detailContainer);
        }


        [HttpGet("GetContainerType")]
        public ActionResult GetContainerType()
        {
            var listContainer = _serviceContainer.GetContainerType();
            return Ok(listContainer);
        }
    }
}
