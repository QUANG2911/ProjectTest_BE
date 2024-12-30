using System.ComponentModel.DataAnnotations;

namespace ProjectTest.Models
{
    public class ContainerExitForm
    {
        [Key]
        [MaxLength(10)]
        public string? IdExitForm { get; set; }

        public DateTime? DateOfRegistration{ get; set; }


        [MaxLength(5)]
        public required string TransportType { get; set; }
        [MaxLength(10)]
        public required string TransportExitLincese { get; set; }

        [Range(0, 1)]
        public int Status { get; set; }

        public DateTime DateOfExitContainer { get; set; }

        public ICollection<Container>? Containers { get; set; }
    }
}
