namespace ProjectTest.DOTs
{
    public class DanhSachPhieuXuatDto
    {
        public required string MAPHIEUXUAT { get; set; }

        public DateTime NGAYLAMPHIEU { get; set; }
        public DateTime NGAYXUAT { get; set; }
        public int TRANGTHAIDUYET { get; set; }
        public required string TENKH { get; set; }
        public required string SDT { get; set; }
    }
}
