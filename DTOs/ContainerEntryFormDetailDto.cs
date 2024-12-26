namespace ProjectTest.DOTs
{
    public class ContainerEntryFormDetailDto
    {
        public string? MaPhieuNhap { get; set; }
        public int Id { get; set; }
        public string? MaContainer { get; set; }
        public required string NumContainer { get; set; }

        public required string LoaiHinhThucVanChuyen { get; set; }

        public required string BienSoDonViVanChuyen { get; set; }

        public int TrongLuongRong { get; set; }

        public int TongTrongLuong { get; set; }

        public DateTime  NgaySanXuat { get; set; }
        
        public required string LoaiContainer {  get; set; }
        public DateTime NgayVanChuyenToiCang { get; set; }
        public int size { get; set; }
        public required string MaIso { get; set; }

    }
}
