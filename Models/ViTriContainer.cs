using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class ViTriContainer
    {
        [Key]
        public int MAVITRI { get; set; }
        [MaxLength(1)]       
        public string? MABLOCK { get; set; }
        [Range(0, 3)]
        public int SOBAY { get; set; }
        [Range(0, 3)]
        public int SOROW { get; set; }
        [Range(0, 4)]
        public int SOTIER { get; set; }

        [Range(0, 1)]
        public int TRANGTHAIRONG { get; set; }
        public ICollection<CT_Container>? cT_Containers { get; set; }
        [ForeignKey("MABLOCK")]
        public Block? Block { get; set; }    
    }
}
