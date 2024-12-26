using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class Block
    {
        [Key]
        [MaxLength(1)]
        public required string MABLOCK { get; set; }
        public int LOAIBAY { get; set; }

        public ICollection<ViTriContainer>? viTriContainers { get; set; }
    }
}
