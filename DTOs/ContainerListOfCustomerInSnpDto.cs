namespace ProjectTest.DTOs
{
    public class ContainerListOfCustomerInSnpDto
    {
        public int Id { get; set; }

        public required string IdContainer { get; set; }

        public required string TypeContainerName { get; set; }

        public int Size { get; set; }
        public DateTime DateOfEntryContainer { get; set; }
    }
}
