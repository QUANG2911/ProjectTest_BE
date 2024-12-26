using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTest.Models
{
    [PrimaryKey(nameof(Id), nameof(MaViTri))]
    public class DetailContainer
    {
        public int Id { get; set; }
        public int MaViTri { get; set; }

        [Required]
        public DateTime ThoiGianBatDau { get; set; }

        public DateTime? ThoiGianKetThuc { get; set; }

        [ForeignKey("Id")]
        public Container? Container { get; set; }
        [ForeignKey("MaViTri")]
        public ViTriContainer? ViTriContainer { get; set; }

    }
    
}
