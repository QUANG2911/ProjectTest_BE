namespace ProjectTest.DOTs
{
    public class ContainerListExitDto
    {
        public int Id { get; set; }
        public required string IdExitForm {  get; set; }
        public DateTime DateOfExitContainer { get; set; }
        public int Status { get; set; }
        public required string CustomerName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string IdContainer { get; set; }
        public int  Size { get; set; }
        public required string TypeContainerName { get; set; }

        public required string TranportExitType { get; set; }

        public required string TransportExitLicensePlate { get; set; }


        public DateTime? DateOfEntryContainer { get; set; }
    }
}
