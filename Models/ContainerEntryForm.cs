using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class ContainerEntryForm
    {
        [Key]
        [MaxLength(5)]
        public required string MaPhieuNhap { get; set; }

        [Required]
        public DateTime NgayDK { get; set; }

        public DateTime NgayGiaoContainer { get; set; }

        [Range(0, 1)]
        public int TrangThaiDuyet { get; set; }

        [MaxLength(10)]
       
        public int Id { get; set; }

        [MaxLength(5)]
        public required string DonViVanChuyen { get; set; }
        [MaxLength(10)]
        public required string BienSoDonViVanChuyen { get; set; }

        [ForeignKey("Id")]
        public Container? Container { get; set; }
    }
}
