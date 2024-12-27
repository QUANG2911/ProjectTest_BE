namespace ProjectTest.DOTs
{
    public class ContainerExitFormListDto
    {
        public required string IdExitForm { get; set; }

        public DateTime DateOfExitRegistration { get; set; }
        public DateTime DateOfExitContainer { get; set; }
        public int Status { get; set; }
        public required string CustomerName { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
