namespace ProjectTest.DOTs
{
    public class ThongTinPhieuNhapDto
    {
        public string? maPhieuNhap { get; set; }
        public int Id { get; set; }
        public string? maContainer { get; set; }
        public required string numContainer { get; set; }

        public required string loaiHinhThucVanChuyen { get; set; }

        public required string bienSoDonViVanChuyen { get; set; }

        public int trongLuongRong { get; set; }

        public int tongTrongLuong { get; set; }

        public DateTime  ngaySanXuat { get; set; }
        
        public required string loaiContainer {  get; set; }
        public DateTime ngayVanChuyenToiCang { get; set; }
        public int size { get; set; }
        public required string maIso { get; set; }

    }
}
