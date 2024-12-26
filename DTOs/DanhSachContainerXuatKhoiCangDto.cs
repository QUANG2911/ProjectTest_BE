namespace ProjectTest.DOTs
{
    public class DanhSachContainerXuatKhoiCangDto
    {
        public int Id { get; set; }
        public required string MAPHIEUXUAT {  get; set; }
        public DateTime NGAYXUAT { get; set; }
        public int TRANGTHAIDUYET { get; set; }
        public required string TENKH { get; set; }
        public required string SDT { get; set; }
        public required string MACONTAINER { get; set; }
        public int  SIZE { get; set; }
        public required string TENLOAI { get; set; }

        public required string donViXuatCang { get; set; }

        public required string bienSoDonViVanChuyen { get; set; }


        public DateTime? ngaygiaocontainer { get; set; }
    }
}
