using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class ContainerLocation
    {
        [Key]
        public int IdLoctation { get; set; }
        [MaxLength(1)]       
        public string? IdBlock { get; set; }
        [Range(0, 3)]
        public int BayLocation { get; set; }
        [Range(0, 3)]
        public int RowLocation { get; set; }
        [Range(0, 4)]
        public int TierLocation { get; set; }

        [Range(0, 1)]
        public int LocationSatus { get; set; }
        public ICollection<DetailContainer>? DetailContainers { get; set; }
        [ForeignKey("MaBlock")]
        public Block? Blocks { get; set; }    
    }
}
