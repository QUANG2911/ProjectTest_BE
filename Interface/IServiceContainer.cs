using Microsoft.AspNetCore.Mvc;
using ProjectTest.DOTs;
using ProjectTest.DTOs;
using ProjectTest.Models;

namespace ProjectTest.Interface
{
    public interface IServiceContainer
    {
        //****************************CONTAINER**********************************
        Task<List<ContainerListDto>> GetDanhSachContainerAsync();

        ContainerDetailDTO GetDetailContainer(int id, DateTime ngayDoiViTri);

        //****************************PHIEU NHAP**********************************

        Task<List<ContainerEntryFormListDto>> GetDanhSachPhieuNhap(string idUser);

        ContainerEntryFormDetailDto GetDetailPhieuNhap(string maPhieuNhap);

        ContainerEntryForm UpdatePhieuNhap(string maPhieuNhap, int trangThai);

        void CreateViTriContainer(int ContainerSize, int SoBay, int soRow, int soTier);

        void CreateCT_Container(int idViTri, int idContainer);

        ContainerEntryForm CreatePhieuNhap(string idUser, ContainerEntryFormDetailDto phieuNhap);
        void CreateContainer(string maContainer, string maIso, string idUser, string maLoai, int maxWeight, int tareWeight, string numContainer, int size, DateTime ngaySanXuat, DateTime ngayVanChuyenToiCang);

        //****************************PHIEU XUAT**********************************
        Task<List<ContainerExitFormListDto>> GetDanhSachPhieuXuatDtos(string idUser);

        Task<List<ContainerListExitDto>> GetDetailPhieuXuatDtos(string maphieu);

        ContainerExitForm UpdateTrangThaiPhieuXuat(string maphieu, int TRANGTHAIDUYET);

        Task<List<ContainerListOfCustomerInSnpDto>> GetDsContainerCuaUserTrongCang(string idUser);

        ContainerExitForm CreatePhieuXuat(string idUser, string idContainer, ContainerExitFormDetailDto thongTinPhieuXuat);


        //****************************LOAICONTAINER**********************************
        List<ContainerType> GetLoaiContainer();

       

    }
}
