
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
    public class DanhSachContainerController : ControllerBase
    {
        private readonly Interface.IServiceContainer _Icontext;

        public DanhSachContainerController(Interface.IServiceContainer Icontext)
        {
            _Icontext = Icontext;
        }

        [HttpGet("GetDanhSachContainer")]
        public async Task<ActionResult> getDanhSachContainer()
        {
            var dsCcontainers = await _Icontext.GetDanhSachContainerAsync();
            return Ok(dsCcontainers);
        }


        [HttpGet("GetChiTietContainer/{id}/{ngayDoiViTri}")]
        public ActionResult getThongTinContainer(int id, DateTime ngayDoiViTri)
        {
            var thongTinCoBan = _Icontext.GetDetailContainer(id,ngayDoiViTri);
            return Ok(thongTinCoBan);
        }


        [HttpGet("getLoaiContainer")]
        public ActionResult getLoaiContainer()
        {
            var dsLoaiContainer =  _Icontext.GetLoaiContainer();
            return Ok(dsLoaiContainer);
        }
    }
}
