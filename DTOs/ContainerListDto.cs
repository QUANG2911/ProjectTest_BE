using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectTest.DOTs
{
    public class ContainerListDto
    {
        public int Id { get; set; }
        public required string  IdContainer { get; set; }

        public required string CustomerName { get; set; }

        public required string PhoneNumber { get; set; }

        public DateTime DateOfEntryContainer { get; set; }

        public DateTime? DateOfExitContainer { get; set; }

    }
}
