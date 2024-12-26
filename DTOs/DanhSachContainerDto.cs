using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectTest.DOTs
{
    public class DanhSachContainerDto
    {
        public int id { get; set; }
        public required string  maContainer { get; set; }
        public required string numContainer { get; set; }

        public required string tenKh { get; set; }

        public required string SDT { get; set; }

        public DateTime ngayDiToiViTri { get; set; }

        public DateTime? ngayXuatCang { get; set; }

    }
}
