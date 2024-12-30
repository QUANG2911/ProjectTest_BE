using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace ProjectTest.Models
{
    public class Container
    {
        [Key]       
        public int Id { get; set; }

        [MaxLength(10)]
        public required string SeriContainer { get; set; }

        [MaxLength(7)]
        public required string NumContainer { get; set; }

        [MaxLength(1)]        
        public string? IdTypeContainer { get; set; }

        [MaxLength(3)]        
        public string? IdCustomer { get; set; }
        [MaxLength(5)]
        public required string IsoCode { get; set; }
        [MaxLength(10)]
        public string? IdExitForm { get; set; }

        public int Size { get; set; }

        public int MaxWeight { get; set; }

        public int TareWeight { get; set; }

        public DateTime DateOfManufacture { get; set; }
        [MaxLength(50)]
        public string? ContainerStatus { get; set; }

        [ForeignKey("IdCustomer")]
        public Customer? Customer { get; set; }
        [ForeignKey("IdTypeContainer")]
        public ContainerType? ContainerType { get; set; }

        [ForeignKey("IdExitForm")]
        public ContainerExitForm? ContainerExitForm { get; set; }

        public ICollection<ContainerEntryForm>? ContainerEntryForms { get; set; }

        public ICollection<DetailContainer>? DetailContainers { get; set; }

  
    }
}

