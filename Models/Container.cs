using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace ProjectTest.Models
{
    public class Container
    {
        [Key]       
        public int id { get; set; }

        [MaxLength(10)]
        public required string MACONTAINER { get; set; }

        [MaxLength(7)]
        public required string NUMCONTAINER { get; set; }

        [MaxLength(1)]        
        public string? MALOAI { get; set; }

        [MaxLength(3)]        
        public string? MAKH { get; set; }
        [MaxLength(5)]
        public required string ISOCODE { get; set; }
        [MaxLength(10)]
        public string? MAPHIEUXUAT { get; set; }

        public int Size { get; set; }

        public int MAXWEIGHT { get; set; }

        public int TAREWEIGHT { get; set; }

        public DateTime NGAYSANXUAT { get; set; }
        [MaxLength(50)]
        public string? TINHTRANG { get; set; }

        [ForeignKey("MAKH")]
        public KhachHang? khachHang { get; set; }
        [ForeignKey("MALOAI")]
        public LoaiContainer? LoaiContainer { get; set; }

        [ForeignKey("MAPHIEUXUAT")]
        public PhieuXuat? phieuXuat { get; set; }

        public ICollection<PhieuNhap>? PhieuNhaps { get; set; }

        public ICollection<CT_Container>? cT_Containers { get; set; }

  
    }
}

