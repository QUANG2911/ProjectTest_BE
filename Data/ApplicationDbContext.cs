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


        public DbSet<ContainerLocation> ViTriContainers { get; set; }

        public DbSet<Block> Blocks { get; set; }

        public DbSet<Container> Containers { get; set; }

        public DbSet<DetailContainer> ContainerDetails { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<ContainerType> ContainerTypes { get; set; }

        public DbSet<ContainerEntryForm> ContainerEntryForms { get; set; }

        public DbSet<ContainerExitForm> ContainerExitForms { get; set; }

        public DbSet<UserAccount> Accounts { get; set; }

        public DbSet<Report> Reports { get; set; }
    }
}
