namespace ProjectTest.DTOs
{
    public class ContainerListOfCustomerInSnpDto
    {
        public int Id { get; set; }

        public required string MaContainer { get; set; }

        public required string TenLoai { get; set; }

        public int Size { get; set; }
        public DateTime NgayGiaoContainer { get; set; }
    }
}
