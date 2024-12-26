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
            modelBuilder.Entity<ContainerListDto>().HasNoKey();
            modelBuilder.Entity<ContainerEntryFormListDto>().HasNoKey();
            modelBuilder.Entity<ContainerExitFormListDto>().HasNoKey();
            modelBuilder.Entity<ContainerListExitDto>().HasNoKey();
            modelBuilder.Entity<ContainerListOfCustomerInSnpDto>().HasNoKey();
        }


        public DbSet<ViTriContainer> ViTriContainers { get; set; }

        public DbSet<Block> blocks { get; set; }

        public DbSet<Container> containers { get; set; }

        public DbSet<DetailContainer> cT_Containers { get; set; }

        public DbSet<Customer> khachHangs { get; set; }

        public DbSet<ContainerType> loaiContainers { get; set; }

        public DbSet<ContainerEntryForm> phieuNhaps { get; set; }

        public DbSet<ContainerExitForm> pHIEUXUATs { get; set; }

        public DbSet<UserAccount> taiKhoans { get; set; }

        public DbSet<Report> Reports { get; set; }
    }
}
