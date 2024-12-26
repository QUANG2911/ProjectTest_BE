namespace ProjectTest.DTOs
{
    public class DanhSachContainerCuaKhTonDto
    {
        public int id { get; set; }

        public required string maContainer { get; set; }

        public required string tenLoai { get; set; }

        public int size { get; set; }
        public DateTime ngayGiaoContainer { get; set; }
    }
}
