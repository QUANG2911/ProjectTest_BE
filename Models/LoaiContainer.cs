using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectTest.Models
{
    public class LoaiContainer
    {
        [Key]
        [MaxLength(1)]
        public required string MALOAI { get; set; }
        [MaxLength(50)]
        public required string TENLOAI { get; set; }

        public ICollection<Container>? containers { get; set; }
    }
}
