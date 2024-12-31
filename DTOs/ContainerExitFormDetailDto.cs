using System.ComponentModel.DataAnnotations;

namespace ProjectTest.DTOs
{
    public class ContainerExitFormDetailDto
    {
        public required string TransportExitType { get; set; }
        public required string TransportExitLicensePlate { get; set; }

        public DateTime DateOfExitContainer { get; set; }
    }
}
