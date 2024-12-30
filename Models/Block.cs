using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class Block
    {
        [Key]
        [MaxLength(1)]
        public required string IdBlock { get; set; }
        public int BayType { get; set; }

        public ICollection<ContainerLocation>? ContainerLocation { get; set; }
    }
}
