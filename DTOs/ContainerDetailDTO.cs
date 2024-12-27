namespace ProjectTest.DOTs
{
    public class ContainerDetailDTO
    {
        public int Id { get; set; }
        public required string IdContainer { get; set; }
        public required string NumContainer { get; set; }

        public required string IsoCode { get; set; }  
        public DateTime DateOfEntryContainer { get; set; }

        public DateTime? DateOfExitContainer { get; set; }

        public required string TypeContainer { get; set; }

        public int Size { get; set; }

        public float TareWeight {  get; set; }

        public float MaxWeight { get; set; }
        public string? StatusOfContainer { get; set; }

        public string? TransportEntryType { get; set;}

        public string? TransportExitType { get; set; }   
        public string? LocationContainer { get; set; }    


    }
}
