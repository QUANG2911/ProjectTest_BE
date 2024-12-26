using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectTest.DOTs
{
    public class ContainerListDto
    {
        public int Id { get; set; }
        public required string  MaContainer { get; set; }
        public required string NumContainer { get; set; }

        public required string TenKh { get; set; }

        public required string Sdt { get; set; }

        public DateTime NgayDiToiViTri { get; set; }

        public DateTime? NgayXuatCang { get; set; }

    }
}
