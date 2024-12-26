namespace ProjectTest.DOTs
{
    public class ThongTinContainerDTO
    {
        public int Id { get; set; }
        public required string maContainer { get; set; }
        public required string numContainer { get; set; }

        public required string MaIso { get; set; }  
        public DateTime ngayDiToiViTri { get; set; }

        public DateTime? ngayXuatCang { get; set; }

        public required string loaiContainer { get; set; }

        public int size { get; set; }

        public float trongLuongRong {  get; set; }

        public float trongLuongTong { get; set; }
        public string? tinhTrang { get; set; }

        public string? donViDuaToiCang { get; set;}

        public string? DonViXuatCang { get; set; }   
        public string? viTriHienTai { get; set; }    


    }
}
