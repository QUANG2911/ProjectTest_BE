using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTest.Models
{
    public class TaiKhoan
    {
        [Key]
        public int STT { get; set; }
        
        [MaxLength(3)]
        public string? MAKH { get; set; }
        [MaxLength(3)]
        public string? MANV { get; set; }
        public required string LOAIACCOUNT { get; set; }

        public required string PASS { get; set; }
        
        public required string USERNAME { get; set; }

        [ForeignKey("MAKH")]
        public KhachHang? khachHang { get; set; }
    }
}
