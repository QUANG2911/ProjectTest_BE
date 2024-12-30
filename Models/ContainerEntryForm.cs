using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class ContainerEntryForm
    {
        [Key]
        [MaxLength(5)]
        public required string IdEntryForm { get; set; }

        [Required]
        public DateTime DateRegistered { get; set; }

        public DateTime DateOfEntryContainer { get; set; }

        [Range(0, 1)]
        public int Status { get; set; }

        [MaxLength(10)]
       
        public int Id { get; set; }

        [MaxLength(5)]
        public required string TransportEntryType { get; set; }
        [MaxLength(10)]
        public required string TransportEntryLicense { get; set; }

        [ForeignKey("Id")]
        public Container? Container { get; set; }
    }
}
