using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class Block
    {
        [Key]
        [MaxLength(1)]
        public required string MaBlock { get; set; }
        public int LoaiBay { get; set; }

        public ICollection<ViTriContainer>? viTriContainers { get; set; }
    }
}
