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
                IdContainer = thongTinCoBan.MaContainer,
                NumContainer = thongTinCoBan.NumContainer,
                TypeContainer = loaiContainer,
                IsoCode = thongTinCoBan.IsoCode,
                Size = thongTinCoBan.Size,
                TareWeight = thongTinCoBan.TareWeight,
                MaxWeight = thongTinCoBan.MaxWeight,
                DateOfEntryContainer = thongTinVanChuyen.First().ThoiGianBatDau,
                DateOfExitContainer = thongTinVanChuyen.First().ThoiGianKetThuc,
                StatusOfContainer = thongTinCoBan.TinhTrang,
                LocationContainer = thongTinVanChuyen.First().MaBlock + "," + thongTinVanChuyen.First().SoBay + "," + thongTinVanChuyen.First().SoTier + "," + thongTinVanChuyen.First().SoRow,
                TransportEntryType = donViNhap,
                TransportExitType = donViXuat
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
            var detailEntryContainerForm = _context.ContainerEntryForms.Where(p => p.MaPhieuNhap == idEntryForm).FirstOrDefault();

            if (detailEntryContainerForm == null)
            {
                throw new Exception("phiếu nhập không tồn tại");
            }
                var detailContainer = _context.Containers.Where(p => p.Id == detailEntryContainerForm.Id).FirstOrDefault();
            if (detailContainer == null)
            {
                throw new Exception("container không tồn tại");
            }
            var loaiConatiner = _context.ContainerTypes.Where(p => p.MaLoai == detailContainer.MaLoai).FirstOrDefault();
            if(loaiConatiner == null)
                throw new Exception("Hệ thống chưa tồn tại loại container này");

            var containerEntryFormDetailDto = new ContainerEntryFormDetailDto
            {
                Id = detailContainer.Id,
                IdEntryForm = idEntryForm,
                IdContainer = detailContainer.MaContainer,
                DateOfManufacture = detailContainer.NgaySanXuat,
                NumContainer = detailContainer.NumContainer,
                TypeContainer = loaiConatiner.TenLoai,
                IsoCode = detailContainer.IsoCode,
                Size = detailContainer.Size,
                TareWeight = detailContainer.TareWeight,
                MaxWeight = detailContainer.MaxWeight,
                DateOfContainerEntry = detailEntryContainerForm.NgayGiaoContainer,
                TransportEntryType = detailEntryContainerForm.DonViVanChuyen,
                TransportEntryLicensePlate = detailEntryContainerForm.BienSoDonViVanChuyen
            };
  
            return containerEntryFormDetailDto;
        }

        public void CreateContainerLocation(int ContainerSize,int SoBay, int soRow, int soTier)
        {
            CaculateContainerLocation _toanViTriContainer = new CaculateContainerLocation();
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
            CaculateContainerLocation _toanViTriContainer = new CaculateContainerLocation();
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

        public void CreateContainer(string idContainer, string isoCode, string idUser, string typeContainer, int maxWeight, int tareWeight, string numContainer, int size, DateTime dateOfManufacture, DateTime dateOfContainerEntry)
        {
            ///Ktra container trong Cang
            var checkContainer = _context.Containers.Where(p => p.NumContainer == numContainer).FirstOrDefault();

            if (checkContainer != null && checkContainer.MaPhieuXuat != null)
            {
                var checkPhieuXuat = _context.ContainerExitForms.Where(p => p.MaPhieuXuat == checkContainer.MaPhieuXuat).FirstOrDefault();
                if (checkPhieuXuat != null && checkPhieuXuat.NgayXuat >= dateOfContainerEntry)
                {
                    throw new Exception("Container này hiện chưa xuất cảng, không thể làm phiếu nhập cho nó.");
                }
            }
            else if (checkContainer != null && checkContainer.MaPhieuXuat == null)
            {
                throw new Exception("Container này hiện chưa có phiếu xuất,đang tồn tại trong cảng và không thể làm phiếu nhập cho nó.");
            }
            ////////////////////////////
            Container container = new Container
            {
                MaContainer = idContainer,
                IsoCode = isoCode,
                MaKH = idUser,
                MaLoai = typeContainer,
                MaxWeight = maxWeight,
                TareWeight = tareWeight,
                NumContainer = numContainer,
                Size = size,
                NgaySanXuat = dateOfManufacture
            };
            _context.Containers.Add(container);
            _context.SaveChanges();
        }

        public ContainerEntryForm CreateContainerEntryForm(string idUser, ContainerEntryFormDetailDto containerEntryFormDetailDto)
        {
            int idContainer = 0;
            var getMacontainer = _context.Containers.OrderByDescending(p => p.Id).FirstOrDefault();
            if (getMacontainer != null) 
                idContainer = getMacontainer.Id;
            string maContainer = idUser + containerEntryFormDetailDto.TypeContainer + containerEntryFormDetailDto.NumContainer;

            CreateContainer(maContainer, containerEntryFormDetailDto.IsoCode, idUser, containerEntryFormDetailDto.TypeContainer, containerEntryFormDetailDto.TareWeight, containerEntryFormDetailDto.MaxWeight, containerEntryFormDetailDto.NumContainer, containerEntryFormDetailDto.Size, containerEntryFormDetailDto.DateOfManufacture, containerEntryFormDetailDto.DateOfContainerEntry);

            string idEntryForm = idUser + _context.ContainerEntryForms.Count();
            ContainerEntryForm entryForm = new ContainerEntryForm
            {
                MaPhieuNhap = idEntryForm,
                Id = idContainer + 1,
                DonViVanChuyen = containerEntryFormDetailDto.TransportEntryType,
                BienSoDonViVanChuyen = containerEntryFormDetailDto.TransportEntryLicensePlate,
                NgayDK = DateTime.Today,
                NgayGiaoContainer = containerEntryFormDetailDto.DateOfContainerEntry,
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

        public async Task<List<ContainerListExitDto>> GetInformationContainerExitForm(string idExitForm)
        {
            var containerExitList = await _context.Set<ContainerListExitDto>()
                                                .FromSqlRaw("exec DanhSachContainerPhieuXuat @maPhieu = {0}", idExitForm)
                                                .ToListAsync();
            return containerExitList;
        }

        public ContainerExitForm UpdateStatusContainerExitForm(string idExitForm, int status)
        {
            var exitFormList = _context.ContainerExitForms.Where(p => p.MaPhieuXuat == idExitForm).FirstOrDefault();
            if (exitFormList == null)
                throw new Exception("Phiếu xuất không tồn tại.");
            
            if(status == 1)
            {
                var containerExitList = _context.Containers.Where(p => p.MaPhieuXuat == idExitForm).ToList();

                foreach (var s in containerExitList)
                {
                    var ct_Xuat = _context.ContainerDetails.Where(p => p.ThoiGianKetThuc == null && p.Id == s.Id).FirstOrDefault();
                    if (ct_Xuat != null)
                        ct_Xuat.ThoiGianKetThuc = exitFormList.NgayXuat;
                }
            }

            exitFormList.TrangThaiDuyet = status;
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

        public ContainerExitForm CreateContainerExitForm(string idUser, string idContainer, ContainerExitFormDetailDto containerExitFormDetailDto)
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
                DonViVanChuyen = containerExitFormDetailDto.TransportExitType,
                MaSoDonViVanChuyen = containerExitFormDetailDto.TransportExitLicensePlate,
                NgayXuat = containerExitFormDetailDto.DateOfExitContainer,
                TrangThaiDuyet = 0
            };

            for (int i = 0; i < (listContainer.Length - 1); i++)
            {
                int maId = int.Parse(listContainer[i]);
                var ct_Container = _context.ContainerDetails.Where(p => p.Id == maId).FirstOrDefault();
                if (ct_Container != null)
                {
                    ct_Container.ThoiGianKetThuc = containerExitFormDetailDto.DateOfExitContainer;
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
            var containerTypes = _context.ContainerTypes.ToList();
            return containerTypes;
        }
    }
}
