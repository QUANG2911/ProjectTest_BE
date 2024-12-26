using Microsoft.AspNetCore.Mvc;
using ProjectTest.DOTs;
using ProjectTest.DTOs;
using ProjectTest.Models;

namespace ProjectTest.Interface
{
    public interface I_ServiceContainer
    {
        //****************************CONTAINER**********************************
        Task<List<DanhSachContainerDto>> GetDanhSachContainerAsync();

        ThongTinContainerDTO GetDetailContainer(int id, DateTime ngayDoiViTri);

        //****************************PHIEU NHAP**********************************

        Task<List<DanhSachPhieuNhapDto>> GetDanhSachPhieuNhap(string idUser);

        ThongTinPhieuNhapDto GetDetailPhieuNhap(string maPhieuNhap);

        PhieuNhap UpdatePhieuNhap(string maPhieuNhap, int trangThai);

        ViTriContainer CreateViTriContainer(int ContainerSize, int SoBay, int soRow, int soTier);

        CT_Container CreateCT_Container(int idViTri, int idContainer);

        PhieuNhap CreatePhieuNhap(string idUser, ThongTinPhieuNhapDto phieuNhap);
        Container CreateContainer(string maContainer, string maIso, string idUser, string maLoai, int maxWeight, int tareWeight, string numContainer, int size, DateTime ngaySanXuat);

        //****************************PHIEU XUAT**********************************
        Task<List<DanhSachPhieuXuatDto>> GetDanhSachPhieuXuatDtos(string idUser);

        Task<List<DanhSachContainerXuatKhoiCangDto>> GetDetailPhieuXuatDtos(string maphieu);

        PhieuXuat UpdateTrangThaiPhieuXuat(string maphieu, int TRANGTHAIDUYET);

        Task<List<DanhSachContainerCuaKhTonDto>> GetDsContainerCuaUserTrongCang(string idUser);

        PhieuXuat CreatePhieuXuat(string idUser, string idContainer, ThongTinPhieuXuatDto thongTinPhieuXuat);


        //****************************LOAICONTAINER**********************************
        List<LoaiContainer> GetLoaiContainer();

       

    }
}
