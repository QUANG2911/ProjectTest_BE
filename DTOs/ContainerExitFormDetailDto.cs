using System.ComponentModel.DataAnnotations;

namespace ProjectTest.DTOs
{
    public class ContainerExitFormDetailDto
    {
        public required string DonViVanChuyen { get; set; }
        public required string BienSoDonViVanChuyen { get; set; }

        public DateTime NgayXuat { get; set; }
    }
}
