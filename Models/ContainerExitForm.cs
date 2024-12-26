using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class ContainerExitForm
    {
        [Key]
        [MaxLength(10)]
        public string? MaPhieuXuat { get; set; }

        public DateTime? NgayLamPhieu { get; set; }


        [MaxLength(5)]
        public required string DonViVanChuyen { get; set; }
        [MaxLength(10)]
        public required string MaSoDonViVanChuyen { get; set; }

        [Range(0, 1)]
        public int TrangThaiDuyet { get; set; }

        public DateTime? NgayXuat { get; set; }

        public ICollection<Container>? Containers { get; set; }
    }
}
