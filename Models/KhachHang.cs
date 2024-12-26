using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectTest.Models
{
    public class KhachHang
    {
        [Key]
        [MaxLength(3)]
        public required string MAKH { get; set; }
        [MaxLength(50)]
        public required string TENKH { get; set; }

        [MaxLength(10)]
        public required string SDT { get; set; }
        [MaxLength(13)]
        public required string MST { get; set; }

        public ICollection<Container>? containers { get; set; }

        public ICollection<TaiKhoan>? taiKhoans { get; set; }
    }
}
