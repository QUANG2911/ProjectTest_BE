using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace ProjectTest.Models
{
    public class Container
    {
        [Key]       
        public int Id { get; set; }

        [MaxLength(10)]
        public required string MaContainer { get; set; }

        [MaxLength(7)]
        public required string NumContainer { get; set; }

        [MaxLength(1)]        
        public string? MaLoai { get; set; }

        [MaxLength(3)]        
        public string? MaKH { get; set; }
        [MaxLength(5)]
        public required string IsoCode { get; set; }
        [MaxLength(10)]
        public string? MaPhieuXuat { get; set; }

        public int Size { get; set; }

        public int MaxWeight { get; set; }

        public int TareWeight { get; set; }

        public DateTime NgaySanXuat { get; set; }
        [MaxLength(50)]
        public string? TinhTrang { get; set; }

        [ForeignKey("MaKH")]
        public Customer? khachHang { get; set; }
        [ForeignKey("MaLoai")]
        public ContainerType? LoaiContainer { get; set; }

        [ForeignKey("MaPhieuXuat")]
        public ContainerExitForm? phieuXuat { get; set; }

        public ICollection<ContainerEntryForm>? PhieuNhaps { get; set; }

        public ICollection<DetailContainer>? cT_Containers { get; set; }

  
    }
}

