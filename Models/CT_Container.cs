using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTest.Models
{
    [PrimaryKey(nameof(id), nameof(MAVITRI))]
    public class CT_Container
    {
        public int id { get; set; }
        public int MAVITRI { get; set; }

        [Required]
        public DateTime THOIGIANBATDAU { get; set; }

        public DateTime? THOIGIANKETTHUC { get; set; }

        [ForeignKey("id")]
        public Container? Container { get; set; }
        [ForeignKey("MAVITRI")]
        public ViTriContainer? viTriContainer { get; set; }

    }
    
}
