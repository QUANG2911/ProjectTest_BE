using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectTest.Models
{
    public class Customer
    {
        [Key]
        [MaxLength(3)]
        public required string MaKH { get; set; }
        [MaxLength(50)]
        public required string TenKH { get; set; }

        [MaxLength(10)]
        public required string Sdt { get; set; }
        [MaxLength(13)]
        public required string Mst { get; set; }

        public ICollection<Container>? containers { get; set; }

        public ICollection<UserAccount>? taiKhoans { get; set; }
    }
}
