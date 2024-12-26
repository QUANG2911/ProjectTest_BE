namespace ProjectTest.DOTs
{
    public class ContainerListExitDto
    {
        public int Id { get; set; }
        public required string MaPhieuXuat {  get; set; }
        public DateTime NgayXuat { get; set; }
        public int TrangThaiDuyet { get; set; }
        public required string TenKh { get; set; }
        public required string Sdt { get; set; }
        public required string MaContainer { get; set; }
        public int  Size { get; set; }
        public required string TenLoai { get; set; }

        public required string DonViXuatCang { get; set; }

        public required string BienSoDonViVanChuyen { get; set; }


        public DateTime? Ngaygiaocontainer { get; set; }
    }
}
