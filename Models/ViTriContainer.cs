using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class ViTriContainer
    {
        [Key]
        public int MaViTri { get; set; }
        [MaxLength(1)]       
        public string? MaBlock { get; set; }
        [Range(0, 3)]
        public int SoBay { get; set; }
        [Range(0, 3)]
        public int SoRow { get; set; }
        [Range(0, 4)]
        public int SoTier { get; set; }

        [Range(0, 1)]
        public int TrangThaiRong { get; set; }
        public ICollection<DetailContainer>? cT_Containers { get; set; }
        [ForeignKey("MaBlock")]
        public Block? Block { get; set; }    
    }
}
