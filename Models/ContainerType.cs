using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectTest.Models
{
    public class ContainerType
    {
        [Key]
        [MaxLength(1)]
        public required string MaLoai { get; set; }
        [MaxLength(50)]
        public required string TenLoai { get; set; }

        public ICollection<Container>? containers { get; set; }
    }
}
