namespace ProjectTest.DOTs
{
    public class ContainerEntryFormListDto
    {
        public required string IdEntryForm {  get; set; }

        public DateTime DateOfEntryRegistration { get; set; }
        public DateTime DateOfEntryContainer { get; set; }
        public int Status { get; set; }
        public required string CustomerName { get; set; }
        public required string PhoneNumber { get; set; }

    }
}
