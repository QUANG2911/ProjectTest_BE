using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Data;
using ProjectTest.DOTs;
using ProjectTest.DTOs;
using ProjectTest.Interface;
using ProjectTest.Math;
//using System.ComponentModel;
using ProjectTest.Models;
namespace ProjectTest.Service
{
    public class ContainerService : IServiceContainer
    {
        private ApplicationDbContext _context;

        public ContainerService(ApplicationDbContext context)
        {
            _context = context;
        }
        //***********************************Container******************************************
        public async Task<List<ContainerListDto>> GetContainerListAsync()
        {
            var dsCcontainers = await _context.Set<ContainerListDto>()
                                        .FromSqlRaw("select * from DanhSachConTainerOCang") // view
                                        .ToListAsync();
            return dsCcontainers;
        }

        public ContainerDetailDTO GetInformationContainer(int id, DateTime dateChangeLocation)
        {
            var thongTinCoBan = _context.Containers.Where(p => p.Id == id).First();

            string loaiContainer = _context.ContainerTypes.Where(p => p.MaLoai == thongTinCoBan.MaLoai).First().TenLoai;

            string donViXuat = "Chưa có phiếu xuất";

            if (thongTinCoBan.MaPhieuXuat != null)
            {
                var exitForm = _context.ContainerExitForms.Where(p => p.MaPhieuXuat == thongTinCoBan.MaPhieuXuat).FirstOrDefault();
                if(exitForm != null)
                {
                    donViXuat = exitForm.DonViVanChuyen;
                }                
            }
            var phieuNhap = _context.ContainerEntryForms.Where(p => p.Id == id).FirstOrDefault();
            if (phieuNhap == null)
            {
                throw new Exception("Không tồn tại phiếu nhập này");
            }
            string donViNhap = phieuNhap.DonViVanChuyen;


            var thongTinVanChuyen = from ct_Con in _context.ContainerDetails.Where(p => p.Id == id && p.ThoiGianBatDau == dateChangeLocation)
                                    from viTri in _context.ViTriContainers
                                    where ct_Con.MaViTri == viTri.MaViTri
                                    select new { viTri.MaBlock, viTri.SoTier, viTri.SoBay, viTri.SoRow, ct_Con.ThoiGianKetThuc, ct_Con.ThoiGianBatDau };

            ContainerDetailDTO container = new ContainerDetailDTO
            {
                Id = id,
                MaContainer = thongTinCoBan.MaContainer,
                NumContainer = thongTinCoBan.NumContainer,
                LoaiContainer = loaiContainer,
                MaIso = thongTinCoBan.IsoCode,
                Size = thongTinCoBan.Size,
                TrongLuongRong = thongTinCoBan.TareWeight,
                TrongLuongTong = thongTinCoBan.MaxWeight,
                NgayDiToiViTri = thongTinVanChuyen.First().ThoiGianBatDau,
                NgayXuatCang = thongTinVanChuyen.First().ThoiGianKetThuc,
                TinhTrang = thongTinCoBan.TinhTrang,
                ViTriHienTai = thongTinVanChuyen.First().MaBlock + "," + thongTinVanChuyen.First().SoBay + "," + thongTinVanChuyen.First().SoTier + "," + thongTinVanChuyen.First().SoRow,
                DonViDuaToiCang = donViNhap,
                DonViXuatCang = donViXuat
            };
            return container;
        }

        //***********************************PhieuNhap******************************************
        public async Task<List<ContainerEntryFormListDto>> GetContainerEntryFormList(string idUser)
        {
            var danhSachPhieuNhap = await _context.Set<ContainerEntryFormListDto>()
                                   .FromSqlRaw("exec DANHSACHPHIEUNHAP @maUser = {0}", idUser)
                                   .ToListAsync();
            return danhSachPhieuNhap;
        }

        public ContainerEntryFormDetailDto GetInformationContainerEntryForm(string idEntryForm)
        {            
            var thongTinPhieuNhap = _context.ContainerEntryForms.Where(p => p.MaPhieuNhap == idEntryForm).FirstOrDefault();

            if (thongTinPhieuNhap == null)
            {
                throw new Exception("phiếu nhập không tồn tại");
            }
                var thongTinContainer = _context.Containers.Where(p => p.Id == thongTinPhieuNhap.Id).FirstOrDefault();
            if (thongTinContainer == null)
            {
                throw new Exception("container không tồn tại");
            }
            var loaiConatiner = _context.ContainerTypes.Where(p => p.MaLoai == thongTinContainer.MaLoai).FirstOrDefault();
            if(loaiConatiner == null)
                throw new Exception("Hệ thống chưa tồn tại loại container này");

            var thongTinPhieuNhapDto = new ContainerEntryFormDetailDto
            {
                Id = thongTinContainer.Id,
                MaPhieuNhap = idEntryForm,
                MaContainer = thongTinContainer.MaContainer,
                NgaySanXuat = thongTinContainer.NgaySanXuat,
                NumContainer = thongTinContainer.NumContainer,
                LoaiContainer = loaiConatiner.TenLoai,
                MaIso = thongTinContainer.IsoCode,
                size = thongTinContainer.Size,
                TrongLuongRong = thongTinContainer.TareWeight,
                TongTrongLuong = thongTinContainer.MaxWeight,
                NgayVanChuyenToiCang = thongTinPhieuNhap.NgayGiaoContainer,
                LoaiHinhThucVanChuyen = thongTinPhieuNhap.DonViVanChuyen,
                BienSoDonViVanChuyen = thongTinPhieuNhap.BienSoDonViVanChuyen
            };
  
            return thongTinPhieuNhapDto;
        }

        public void CreateContainerLocation(int ContainerSize,int SoBay, int soRow, int soTier)
        {
            TinhToanViTriContainer _toanViTriContainer = new TinhToanViTriContainer();
            var viTriMax = _context.ViTriContainers.OrderByDescending(p => p.MaViTri).FirstOrDefault();

            string x = _toanViTriContainer.getContainerLocation(ContainerSize, SoBay, soRow, soTier);

            string[] viTriMoi = x.Split('/');

            if (viTriMoi[0] == "full")
                throw new Exception("Đã hết chỗ chứa.");


            ViTriContainer viTri1 = new ViTriContainer
            {
                MaBlock = viTriMoi[0],
                SoBay = int.Parse(viTriMoi[1]),
                SoRow = int.Parse(viTriMoi[2]),
                SoTier = int.Parse(viTriMoi[3]),
                TrangThaiRong = 1
            };
            _context.ViTriContainers.Add(viTri1);
            _context.SaveChanges();
        }

        public void CreateDetailContainer(int idViTri, int idContainer)
        {
            DetailContainer cT_Container = new DetailContainer
            {
                Id = idContainer,
                MaViTri = idViTri + 1,
                ThoiGianBatDau = DateTime.Today,
                ThoiGianKetThuc = null
            };
            _context.ContainerDetails.Add(cT_Container);
            _context.SaveChanges();
        }

        public ContainerEntryForm UpdateStatusContainerEntryForm(string idEntryForm, int status)
        {
            TinhToanViTriContainer _toanViTriContainer = new TinhToanViTriContainer();
            // ktra phieu nhap
            var entryForm = _context.ContainerEntryForms.Where(p => p.MaPhieuNhap == idEntryForm).FirstOrDefault();

            if (entryForm == null)
                throw new Exception("Phiếu nhập không tồn tại.");
            var container = _context.Containers.Where(p => p.Id == entryForm.Id).FirstOrDefault();

            if (container == null)
                throw new Exception("Container không tồn tại.");
            if (status == 1)
            {
                int maViTri = 0;
                int soBay = 0;
                int soRow = 1;
                int soTier = 1;
                // ktra cho chua container
                var viTriMax = _context.ViTriContainers.OrderByDescending(p => p.MaViTri).FirstOrDefault();

                if(viTriMax != null)
                {
                    maViTri = viTriMax.MaViTri;
                    soBay = viTriMax.SoBay;
                    soRow = viTriMax.SoRow;
                    soTier = viTriMax.SoTier;
                }    
                CreateContainerLocation(container.Size, soBay, soRow, soTier);

                CreateDetailContainer(maViTri, container.Id);              
            }
            entryForm.TrangThaiDuyet = status;

            _context.SaveChanges();
            return (entryForm);
        }

        public void CreateContainer(string maContainer,string maIso,string idUser, string maLoai,int maxWeight, int tareWeight,string numContainer, int size, DateTime ngaySanXuat, DateTime ngayVanChuyenToiCang)
        {
            ///Ktra container trong Cang
            var checkContainer = _context.Containers.Where(p => p.NumContainer == numContainer).FirstOrDefault();

            if (checkContainer != null && checkContainer.MaPhieuXuat != null)
            {
                var checkPhieuXuat = _context.ContainerExitForms.Where(p => p.MaPhieuXuat == checkContainer.MaPhieuXuat).FirstOrDefault();
                if (checkPhieuXuat != null && checkPhieuXuat.NgayXuat >= ngayVanChuyenToiCang)
                {
                    throw new Exception("Container này hiện chưa xuất cảng, không thể làm phiếu nhập cho nó.");
                }
            }
            else if (checkContainer != null && checkContainer.MaPhieuXuat == null)
            {
                throw new Exception("Container này hiện chưa có phiếu xuất,đang tồn tại trong cảng và không thể làm phiếu nhập cho nó.");
            }
            ////////////////////////////
            ///
            Container container = new Container
            {
                MaContainer = maContainer,
                IsoCode = maIso,
                MaKH = idUser,
                MaLoai = maLoai,
                MaxWeight = maxWeight,
                TareWeight = tareWeight,
                NumContainer = numContainer,
                Size = size,
                NgaySanXuat = ngaySanXuat
            };
            _context.Containers.Add(container);
            _context.SaveChanges();
        }

        public ContainerEntryForm CreateContainerEntryForm(string idUser, ContainerEntryFormDetailDto thongTinPhieuNhapDto)
        {
            int idContainer = 0;
            var getMacontainer = _context.Containers.OrderByDescending(p => p.Id).FirstOrDefault();
            if (getMacontainer != null) 
                idContainer = getMacontainer.Id;
            string maContainer = idUser + thongTinPhieuNhapDto.LoaiContainer + thongTinPhieuNhapDto.NumContainer;

            CreateContainer(maContainer, thongTinPhieuNhapDto.MaIso, idUser, thongTinPhieuNhapDto.LoaiContainer, thongTinPhieuNhapDto.TongTrongLuong, thongTinPhieuNhapDto.TongTrongLuong, thongTinPhieuNhapDto.NumContainer, thongTinPhieuNhapDto.size, thongTinPhieuNhapDto.NgaySanXuat, thongTinPhieuNhapDto.NgayVanChuyenToiCang);

            string idEntryForm = idUser + _context.ContainerEntryForms.Count();
            ContainerEntryForm entryForm = new ContainerEntryForm
            {
                MaPhieuNhap = idEntryForm,
                Id = idContainer + 1,
                DonViVanChuyen = thongTinPhieuNhapDto.LoaiHinhThucVanChuyen,
                BienSoDonViVanChuyen = thongTinPhieuNhapDto.BienSoDonViVanChuyen,
                NgayDK = DateTime.Today,
                NgayGiaoContainer = thongTinPhieuNhapDto.NgayVanChuyenToiCang,
                TrangThaiDuyet = 0
            };

            _context.ContainerEntryForms.Add(entryForm);

            _context.SaveChanges();

            return entryForm;
        }

        //***********************************PHIEUXUAT******************************************
        public async Task<List<ContainerExitFormListDto>> GetContainerExitFormList(string idUser)
        {
            var exitFormList = await _context.Set<ContainerExitFormListDto>()
                                   .FromSqlRaw("exec DANHSACHPHIEUXUAT @maUser ={0}", idUser)
                                   .ToListAsync();
            return exitFormList;
        }

        public async Task<List<ContainerListExitDto>> GetInformationContainerExitForm(string maPhieu)
        {
            var containerExitList = await _context.Set<ContainerListExitDto>()
                                                .FromSqlRaw("exec DanhSachContainerPhieuXuat @maPhieu = {0}", maPhieu)
                                                .ToListAsync();
            return containerExitList;
        }

        public ContainerExitForm UpdateStatusContainerExitForm(string maPhieu, int trangThaiDuyet)
        {
            var exitFormList = _context.ContainerExitForms.Where(p => p.MaPhieuXuat == maPhieu).FirstOrDefault();
            if (exitFormList == null)
                throw new Exception("Phiếu xuất không tồn tại.");
            
            if(trangThaiDuyet == 1)
            {
                var containerExitList = _context.Containers.Where(p => p.MaPhieuXuat == maPhieu).ToList();

                foreach (var s in containerExitList)
                {
                    var ct_Xuat = _context.ContainerDetails.Where(p => p.ThoiGianKetThuc == null && p.Id == s.Id).FirstOrDefault();
                    if (ct_Xuat != null)
                        ct_Xuat.ThoiGianKetThuc = exitFormList.NgayXuat;
                }
            }

            exitFormList.TrangThaiDuyet = trangThaiDuyet;
            _context.SaveChanges();
            return exitFormList;
        }

        public async Task<List<ContainerListOfCustomerInSnpDto>> GetListContainerOfUserInSnp(string idUser)
        {
            var listContainerInSnp = await _context.Set<ContainerListOfCustomerInSnpDto>()
                                                .FromSqlRaw("exec DANHSACHCONTAINERCUAKHCONTON @maKH = {0}", idUser)
                                                .ToListAsync();
            return listContainerInSnp;
        }

        public ContainerExitForm CreateContainerExitForm(string idUser, string idContainer, ContainerExitFormDetailDto thongTinPhieuXuat)
        {
            /// chuoi test
            //   // string listTest = "26,15,17,";

            string[] listContainer = idContainer.Split(',');

            string ExitFormAmount = _context.ContainerExitForms.Count().ToString();

            string maPhieu = idUser + ExitFormAmount;
            ContainerExitForm exitForm = new ContainerExitForm
            {
                MaPhieuXuat = maPhieu,
                NgayLamPhieu = DateTime.Now,
                DonViVanChuyen = thongTinPhieuXuat.DonViVanChuyen,
                MaSoDonViVanChuyen = thongTinPhieuXuat.BienSoDonViVanChuyen,
                NgayXuat = thongTinPhieuXuat.NgayXuat,
                TrangThaiDuyet = 0
            };

            for (int i = 0; i < (listContainer.Length - 1); i++)
            {
                int maId = int.Parse(listContainer[i]);
                var ct_Container = _context.ContainerDetails.Where(p => p.Id == maId).FirstOrDefault();
                if (ct_Container != null)
                {
                    ct_Container.ThoiGianKetThuc = thongTinPhieuXuat.NgayXuat;
                }

                var container = _context.Containers.Where(p => p.Id == maId).FirstOrDefault();
                if (container != null)
                {
                    container.MaPhieuXuat = maPhieu;
                }
            }

            _context.ContainerExitForms.Add(exitForm);

            _context.SaveChanges();

            return exitForm;
        }


        public List<ContainerType> GetContainerType()
        {
            var loaiContainer = _context.ContainerTypes.ToList();
            return loaiContainer;
        }
    }
}
