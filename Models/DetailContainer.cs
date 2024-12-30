using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTest.Models
{
    [PrimaryKey(nameof(Id), nameof(IdLoctation))]
    public class DetailContainer
    {
        public int Id { get; set; }
        public int IdLoctation { get; set; }

        [Required]
        public DateTime TimeBegin { get; set; }

        public DateTime? TimeEnd { get; set; }

        [ForeignKey("Id")]
        public Container? Container { get; set; }
        [ForeignKey("IdLoctation")]
        public ContainerLocation? ContainerLocation { get; set; }

    }
    
}
