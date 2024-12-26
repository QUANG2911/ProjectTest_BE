using System.ComponentModel.DataAnnotations;

namespace ProjectTest.DTOs
{
    public class ThongTinPhieuXuatDto
    {
        public required string DONVIVANCHUYEN { get; set; }
        public required string bienSoDonViVanChuyen { get; set; }

        public DateTime NGAYXUAT { get; set; }
    }
}
