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
    public class ContainerService : I_ServiceContainer
    {
        private ApplicationDbContext _context;

        public ContainerService(ApplicationDbContext context)
        {
            _context = context;
        }
        //***********************************Container******************************************
        public async Task<List<DanhSachContainerDto>> GetDanhSachContainerAsync()
        {
            var dsCcontainers = await _context.Set<DanhSachContainerDto>()
                                        .FromSqlRaw("select * from DanhSachConTainerOCang") // view
                                        .ToListAsync();
            return dsCcontainers;
        }

        public ThongTinContainerDTO GetDetailContainer(int id, DateTime ngayDoiViTri)
        {
            var thongTinCoBan = _context.containers.Where(p => p.id == id).First();

            string loaiContainer = _context.loaiContainers.Where(p => p.MALOAI == thongTinCoBan.MALOAI).First().TENLOAI;

            string donViXuat = "Chưa có phiếu xuất";

            if (thongTinCoBan.MAPHIEUXUAT != null)
            {
                var phieuXuat = _context.pHIEUXUATs.Where(p => p.MAPHIEUXUAT == thongTinCoBan.MAPHIEUXUAT).FirstOrDefault();
                if(phieuXuat != null)
                {
                    donViXuat = phieuXuat.DONVIVANCHUYEN;
                }                
            }
            var phieuNhap = _context.phieuNhaps.Where(p => p.id == id).FirstOrDefault();
            if (phieuNhap == null)
            {
                throw new Exception("Không tồn tại phiếu nhập này");
            }
            string donViNhap = phieuNhap.DONVIVANCHUYEN;


            var thongTinVanChuyen = from ct_Con in _context.cT_Containers.Where(p => p.id == id && p.THOIGIANBATDAU == ngayDoiViTri)
                                    from viTri in _context.ViTriContainers
                                    where ct_Con.MAVITRI == viTri.MAVITRI
                                    select new { viTri.MABLOCK, viTri.SOTIER, viTri.SOBAY, viTri.SOROW, ct_Con.THOIGIANKETTHUC, ct_Con.THOIGIANBATDAU };

            ThongTinContainerDTO container = new ThongTinContainerDTO
            {
                Id = id,
                maContainer = thongTinCoBan.MACONTAINER,
                numContainer = thongTinCoBan.NUMCONTAINER,
                loaiContainer = loaiContainer,
                MaIso = thongTinCoBan.ISOCODE,
                size = thongTinCoBan.Size,
                trongLuongRong = thongTinCoBan.TAREWEIGHT,
                trongLuongTong = thongTinCoBan.MAXWEIGHT,

                ngayDiToiViTri = thongTinVanChuyen.First().THOIGIANBATDAU,
                ngayXuatCang = thongTinVanChuyen.First().THOIGIANKETTHUC,
                tinhTrang = thongTinCoBan.TINHTRANG,
                viTriHienTai = thongTinVanChuyen.First().MABLOCK + "," + thongTinVanChuyen.First().SOBAY + "," + thongTinVanChuyen.First().SOTIER + "," + thongTinVanChuyen.First().SOROW,
                donViDuaToiCang = donViNhap,
                DonViXuatCang = donViXuat
            };
            return container;
        }

        //***********************************PhieuNhap******************************************
        public async Task<List<DanhSachPhieuNhapDto>> GetDanhSachPhieuNhap(string idUser)
        {
            var danhSachPhieuNhap = await _context.Set<DanhSachPhieuNhapDto>()
                                   .FromSqlRaw("exec DANHSACHPHIEUNHAP @maUser = {0}", idUser)
                                   .ToListAsync();
            return danhSachPhieuNhap;
        }

        public ThongTinPhieuNhapDto GetDetailPhieuNhap(string maPhieuNhap)
        {            
            var thongTinPhieuNhap = _context.phieuNhaps.Where(p => p.MAPHIEUNHAP == maPhieuNhap).FirstOrDefault();

            if (thongTinPhieuNhap == null)
            {
                throw new Exception("phiếu nhập không tồn tại");
            }
                var thongTinContainer = _context.containers.Where(p => p.id == thongTinPhieuNhap.id).FirstOrDefault();
            if (thongTinContainer == null)
            {
                throw new Exception("container không tồn tại");
            }
            var loaiConatiner = _context.loaiContainers.Where(p => p.MALOAI == thongTinContainer.MALOAI).FirstOrDefault();
            if(loaiConatiner == null)
                throw new Exception("Hệ thống chưa tồn tại loại container này");

            var thongTinPhieuNhapDto = new ThongTinPhieuNhapDto
            {
                Id = thongTinContainer.id,
                maPhieuNhap = maPhieuNhap,
                maContainer = thongTinContainer.MACONTAINER,
                ngaySanXuat = thongTinContainer.NGAYSANXUAT,
                numContainer = thongTinContainer.NUMCONTAINER,
                loaiContainer = loaiConatiner.TENLOAI,
                maIso = thongTinContainer.ISOCODE,
                size = thongTinContainer.Size,
                trongLuongRong = thongTinContainer.TAREWEIGHT,
                tongTrongLuong = thongTinContainer.MAXWEIGHT,
                ngayVanChuyenToiCang = thongTinPhieuNhap.NGAYGIAOCONTAINER,
                loaiHinhThucVanChuyen = thongTinPhieuNhap.DONVIVANCHUYEN,
                bienSoDonViVanChuyen = thongTinPhieuNhap.BIENSODONVIVANCHUYEN
            };
  
            return thongTinPhieuNhapDto;
        }

        public ViTriContainer CreateViTriContainer(int ContainerSize,int SoBay, int soRow, int soTier)
        {
            TinhToanViTriContainer _toanViTriContainer = new TinhToanViTriContainer();
            var viTriMax = _context.ViTriContainers.OrderByDescending(p => p.MAVITRI).FirstOrDefault();

            string x = _toanViTriContainer.getViTriContainer(ContainerSize, SoBay, soRow, soTier);

            string[] viTriMoi = x.Split('/');

            if (viTriMoi[0] == "full")
                throw new Exception("Đã hết chỗ chứa.");


            ViTriContainer viTri1 = new ViTriContainer
            {
                MABLOCK = viTriMoi[0],
                SOBAY = int.Parse(viTriMoi[1]),
                SOROW = int.Parse(viTriMoi[2]),
                SOTIER = int.Parse(viTriMoi[3]),
                TRANGTHAIRONG = 1
            };
            return viTri1;
        }

        public CT_Container CreateCT_Container(int idViTri, int idContainer)
        {
            CT_Container cT_Container = new CT_Container
            {
                id = idContainer,
                MAVITRI = idViTri + 1,
                THOIGIANBATDAU = DateTime.Today,
                THOIGIANKETTHUC = null
            };
            return cT_Container;
        }

        public PhieuNhap UpdatePhieuNhap(string maPhieuNhap, int trangThai)
        {
            TinhToanViTriContainer _toanViTriContainer = new TinhToanViTriContainer();
            // ktra phieu nhap
            var phieuNhap = _context.phieuNhaps.Where(p => p.MAPHIEUNHAP == maPhieuNhap).FirstOrDefault();

            if (phieuNhap == null)
                throw new Exception("Phiếu nhập không tồn tại.");
            var container = _context.containers.Where(p => p.id == phieuNhap.id).FirstOrDefault();

            if (container == null)
                throw new Exception("Container không tồn tại.");
            if (trangThai == 1)
            {
                int maViTri = 0;
                int soBay = 0;
                int soRow = 1;
                int soTier = 1;
                // ktra cho chua container
                var viTriMax = _context.ViTriContainers.OrderByDescending(p => p.MAVITRI).FirstOrDefault();

                if(viTriMax != null)
                {
                    maViTri = viTriMax.MAVITRI;
                    soBay = viTriMax.SOBAY;
                    soRow = viTriMax.SOROW;
                    soTier = viTriMax.SOTIER;
                }    
                var viTri = CreateViTriContainer(container.Size, soBay, soRow, soTier);

                var ct_Container = CreateCT_Container(maViTri, container.id);
                // luu database
                _context.ViTriContainers.Add(viTri);

                _context.cT_Containers.Add(ct_Container);
            }
            phieuNhap.TRANGTHAIDUYET = trangThai;

            _context.SaveChanges();
            return (phieuNhap);
        }

        public Container CreateContainer(string maContainer,string maIso,string idUser, string maLoai,int maxWeight, int tareWeight,string numContainer, int size, DateTime ngaySanXuat)
        {
            Container container = new Container
            {
                MACONTAINER = maContainer,
                ISOCODE = maIso,
                MAKH = idUser,
                MALOAI = maLoai,
                MAXWEIGHT = maxWeight,
                TAREWEIGHT = tareWeight,
                NUMCONTAINER = numContainer,
                Size = size,
                NGAYSANXUAT = ngaySanXuat
            };
            return container;
        }

        public PhieuNhap CreatePhieuNhap(string idUser, ThongTinPhieuNhapDto thongTinPhieuNhapDto)
        {
            int idContainer = 0;
            var getMacontainer = _context.containers.OrderByDescending(p => p.id).FirstOrDefault();
            if (getMacontainer != null) 
                idContainer = getMacontainer.id;
            string maContainer = idUser + thongTinPhieuNhapDto.loaiContainer + thongTinPhieuNhapDto.numContainer;

            ///Ktra container trong Cang
            var checkContainer = _context.containers.Where(p => p.NUMCONTAINER == thongTinPhieuNhapDto.numContainer).FirstOrDefault();

            if (checkContainer != null && checkContainer.MAPHIEUXUAT != null)
            {
                var checkPhieuXuat = _context.pHIEUXUATs.Where(p => p.MAPHIEUXUAT == checkContainer.MAPHIEUXUAT).FirstOrDefault();
                if( checkPhieuXuat != null && checkPhieuXuat.NGAYXUAT >= thongTinPhieuNhapDto.ngayVanChuyenToiCang)
                {
                    throw new Exception("Container này hiện chưa xuất cảng, không thể làm phiếu nhập cho nó.");
                }    
            }
            else if (checkContainer != null && checkContainer.MAPHIEUXUAT == null)
            {
                throw new Exception("Container này hiện chưa có phiếu xuất,đang tồn tại trong cảng và không thể làm phiếu nhập cho nó.");
            }
            ////////////////////////////
            string maPhieuNhap = idUser + _context.phieuNhaps.Count();
            PhieuNhap phieuNhap = new PhieuNhap
            {
                MAPHIEUNHAP = maPhieuNhap,
                id = idContainer + 1,
                DONVIVANCHUYEN = thongTinPhieuNhapDto.loaiHinhThucVanChuyen,
                BIENSODONVIVANCHUYEN = thongTinPhieuNhapDto.bienSoDonViVanChuyen,
                NGAYDK = DateTime.Today,
                NGAYGIAOCONTAINER = thongTinPhieuNhapDto.ngayVanChuyenToiCang,
                TRANGTHAIDUYET = 0
            };

            Container container = CreateContainer(maContainer, thongTinPhieuNhapDto.maIso, idUser, thongTinPhieuNhapDto.loaiContainer, thongTinPhieuNhapDto.tongTrongLuong, thongTinPhieuNhapDto.tongTrongLuong, thongTinPhieuNhapDto.numContainer, thongTinPhieuNhapDto.size, thongTinPhieuNhapDto.ngaySanXuat);
   
            _context.containers.Add(container);

            _context.phieuNhaps.Add(phieuNhap);

            _context.SaveChanges();

            return phieuNhap;
        }

        //***********************************PHIEUXUAT******************************************
        public async Task<List<DanhSachPhieuXuatDto>> GetDanhSachPhieuXuatDtos(string idUser)
        {
            var danhSachPhieuXuat = await _context.Set<DanhSachPhieuXuatDto>()
                                   .FromSqlRaw("exec DANHSACHPHIEUXUAT @maUser ={0}", idUser)
                                   .ToListAsync();
            return danhSachPhieuXuat;
        }

        public async Task<List<DanhSachContainerXuatKhoiCangDto>> GetDetailPhieuXuatDtos(string maphieu)
        {
            var danhSachContainerXuat = await _context.Set<DanhSachContainerXuatKhoiCangDto>()
                                                .FromSqlRaw("exec DanhSachContainerPhieuXuat @maPhieu = {0}", maphieu)
                                                .ToListAsync();
            return danhSachContainerXuat;
        }

        public PhieuXuat UpdateTrangThaiPhieuXuat(string maphieu, int TRANGTHAIDUYET)
        {
            var danhSach = _context.pHIEUXUATs.Where(p => p.MAPHIEUXUAT == maphieu).FirstOrDefault();
            if (danhSach == null)
                throw new Exception("Phiếu xuất không tồn tại.");


            var listDsContainerXuat = _context.containers.Where(p => p.MAPHIEUXUAT == maphieu).ToList();

            foreach (var s in listDsContainerXuat)
            {
                var ct_Xuat = _context.cT_Containers.Where(p => p.THOIGIANKETTHUC == null && p.id == s.id).FirstOrDefault();
                if (ct_Xuat != null)
                    ct_Xuat.THOIGIANKETTHUC = danhSach.NGAYXUAT;
            }

            danhSach.TRANGTHAIDUYET = TRANGTHAIDUYET;
            _context.SaveChanges();
            return danhSach;
        }

        public async Task<List<DanhSachContainerCuaKhTonDto>> GetDsContainerCuaUserTrongCang(string idUser)
        {
            var listContainerChuaXuat = await _context.Set<DanhSachContainerCuaKhTonDto>()
                                                .FromSqlRaw("exec DANHSACHCONTAINERCUAKHCONTON @maKH = {0}", idUser)
                                                .ToListAsync();
            return listContainerChuaXuat;
        }

        public PhieuXuat CreatePhieuXuat(string idUser, string idContainer, ThongTinPhieuXuatDto thongTinPhieuXuat)
        {
            /// chuoi test
            //   // string listTest = "26,15,17,";

            string[] listContainer = idContainer.Split(',');

            string slgPhieuXuat = _context.pHIEUXUATs.Count().ToString();

            string maPhieu = idUser + slgPhieuXuat;
            PhieuXuat phieuXuat = new PhieuXuat
            {
                MAPHIEUXUAT = maPhieu,
                NGAYLAMPHIEU = DateTime.Now,
                DONVIVANCHUYEN = thongTinPhieuXuat.DONVIVANCHUYEN,
                MASODONVIVANCHUYEN = thongTinPhieuXuat.bienSoDonViVanChuyen,
                NGAYXUAT = thongTinPhieuXuat.NGAYXUAT,
                TRANGTHAIDUYET = 0
            };

            for (int i = 0; i < (listContainer.Length - 1); i++)
            {
                int maId = int.Parse(listContainer[i]);
                var ct_Container = _context.cT_Containers.Where(p => p.id == maId).FirstOrDefault();
                if (ct_Container != null)
                {
                    ct_Container.THOIGIANKETTHUC = thongTinPhieuXuat.NGAYXUAT;
                }

                var container = _context.containers.Where(p => p.id == maId).FirstOrDefault();
                if (container != null)
                {
                    container.MAPHIEUXUAT = maPhieu;
                }
            }

            _context.pHIEUXUATs.Add(phieuXuat);

            _context.SaveChanges();

            return phieuXuat;
        }


        public List<LoaiContainer> GetLoaiContainer()
        {
            var loaiContainer = _context.loaiContainers.ToList();
            return loaiContainer;
        }
    }
}
