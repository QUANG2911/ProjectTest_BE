namespace ProjectTest.DTOs
{
    public class CreateEntryContainerFormDto
    {
        public required string NumContainer { get; set; }

        public required string TransportEntryType { get; set; }

        public required string TransportEntryLicensePlate { get; set; }

        public int TareWeight { get; set; }

        public int MaxWeight { get; set; }

        public DateTime DateOfManufacture { get; set; }

        public required string TypeContainer { get; set; }
        public DateTime DateOfContainerEntry { get; set; }
        public int Size { get; set; }
        public required string IsoCode { get; set; }

    }
}
