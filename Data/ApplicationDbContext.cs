using Microsoft.EntityFrameworkCore;
using ProjectTest.DOTs;
using ProjectTest.DTOs;
using ProjectTest.Models;

namespace ProjectTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình lớp DanhSachContainerDto như một kiểu không được ánh xạ (Keyless Entity)
            modelBuilder.Entity<DanhSachContainerDto>().HasNoKey();
            modelBuilder.Entity<DanhSachPhieuNhapDto>().HasNoKey();
            modelBuilder.Entity<DanhSachPhieuXuatDto>().HasNoKey();
            modelBuilder.Entity<DanhSachContainerXuatKhoiCangDto>().HasNoKey();
            modelBuilder.Entity<DanhSachContainerCuaKhTonDto>().HasNoKey();
        }


        public DbSet<ViTriContainer> ViTriContainers { get; set; }

        public DbSet<Block> blocks { get; set; }

        public DbSet<Container> containers { get; set; }

        public DbSet<CT_Container> cT_Containers { get; set; }

        public DbSet<KhachHang> khachHangs { get; set; }

        public DbSet<LoaiContainer> loaiContainers { get; set; }

        public DbSet<PhieuNhap> phieuNhaps { get; set; }

        public DbSet<PhieuXuat> pHIEUXUATs { get; set; }

        public DbSet<TaiKhoan> taiKhoans { get; set; }

        public DbSet<Report> Reports { get; set; }
    }
}
