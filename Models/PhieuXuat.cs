using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class PhieuXuat
    {
        [Key]
        [MaxLength(10)]
        public string? MAPHIEUXUAT { get; set; }

        public DateTime? NGAYLAMPHIEU { get; set; }


        [MaxLength(5)]
        public required string DONVIVANCHUYEN { get; set; }
        [MaxLength(10)]
        public required string MASODONVIVANCHUYEN { get; set; }

        [Range(0, 1)]
        public int TRANGTHAIDUYET { get; set; }

        public DateTime? NGAYXUAT { get; set; }

        public ICollection<Container>? containers { get; set; }
    }
}
