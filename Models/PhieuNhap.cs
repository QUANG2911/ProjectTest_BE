using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class PhieuNhap
    {
        [Key]
        [MaxLength(5)]
        public required string MAPHIEUNHAP { get; set; }

        [Required]
        public DateTime NGAYDK { get; set; } = DateTime.Now;

        public DateTime NGAYGIAOCONTAINER { get; set; }

        [Range(0, 1)]
        public int TRANGTHAIDUYET { get; set; }

        [MaxLength(10)]
       
        public int? id { get; set; }

        [MaxLength(5)]
        public required string DONVIVANCHUYEN { get; set; }
        [MaxLength(10)]
        public required string BIENSODONVIVANCHUYEN { get; set; }

        [ForeignKey("id")]
        public Container? Container { get; set; }
    }
}
