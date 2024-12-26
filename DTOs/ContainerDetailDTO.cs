namespace ProjectTest.DOTs
{
    public class ContainerDetailDTO
    {
        public int Id { get; set; }
        public required string MaContainer { get; set; }
        public required string NumContainer { get; set; }

        public required string MaIso { get; set; }  
        public DateTime NgayDiToiViTri { get; set; }

        public DateTime? NgayXuatCang { get; set; }

        public required string LoaiContainer { get; set; }

        public int Size { get; set; }

        public float TrongLuongRong {  get; set; }

        public float TrongLuongTong { get; set; }
        public string? TinhTrang { get; set; }

        public string? DonViDuaToiCang { get; set;}

        public string? DonViXuatCang { get; set; }   
        public string? ViTriHienTai { get; set; }    


    }
}
