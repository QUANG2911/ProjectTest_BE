﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTest.Data;

#nullable disable

namespace ProjectTest.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241226084339_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectTest.Models.Block", b =>
                {
                    b.Property<string>("MaBlock")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("LoaiBay")
                        .HasColumnType("int");

                    b.HasKey("MaBlock");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("ProjectTest.Models.Container", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("MaContainer")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("MaKH")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("MaLoai")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("MaPhieuXuat")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySanXuat")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumContainer")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("TareWeight")
                        .HasColumnType("int");

                    b.Property<string>("TinhTrang")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MaKH");

                    b.HasIndex("MaLoai");

                    b.HasIndex("MaPhieuXuat");

                    b.ToTable("Containers");
                });

            modelBuilder.Entity("ProjectTest.Models.ContainerEntryForm", b =>
                {
                    b.Property<string>("MaPhieuNhap")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("BienSoDonViVanChuyen")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("DonViVanChuyen")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("Id")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDK")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayGiaoContainer")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrangThaiDuyet")
                        .HasColumnType("int");

                    b.HasKey("MaPhieuNhap");

                    b.HasIndex("Id");

                    b.ToTable("ContainerEntryForms");
                });

            modelBuilder.Entity("ProjectTest.Models.ContainerExitForm", b =>
                {
                    b.Property<string>("MaPhieuXuat")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("DonViVanChuyen")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("MaSoDonViVanChuyen")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime?>("NgayLamPhieu")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXuat")
                        .HasColumnType("datetime2");

                    b.Property<int>("TrangThaiDuyet")
                        .HasColumnType("int");

                    b.HasKey("MaPhieuXuat");

                    b.ToTable("ContainerExitForms");
                });

            modelBuilder.Entity("ProjectTest.Models.ContainerType", b =>
                {
                    b.Property<string>("MaLoai")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLoai");

                    b.ToTable("ContainerTypes");
                });

            modelBuilder.Entity("ProjectTest.Models.Customer", b =>
                {
                    b.Property<string>("MaKH")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Mst")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TenKH")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaKH");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ProjectTest.Models.DetailContainer", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("MaViTri")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ThoiGianKetThuc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "MaViTri");

                    b.HasIndex("MaViTri");

                    b.ToTable("ContainerDetails");
                });

            modelBuilder.Entity("ProjectTest.Models.Report", b =>
                {
                    b.Property<int>("stt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("stt"));

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ThoiGianQuery")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("stt");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("ProjectTest.Models.UserAccount", b =>
                {
                    b.Property<int>("Stt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Stt"));

                    b.Property<string>("LoaiAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaKH")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("MaNv")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Stt");

                    b.HasIndex("MaKH");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("ProjectTest.Models.ViTriContainer", b =>
                {
                    b.Property<int>("MaViTri")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaViTri"));

                    b.Property<string>("MaBlock")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("SoBay")
                        .HasColumnType("int");

                    b.Property<int>("SoRow")
                        .HasColumnType("int");

                    b.Property<int>("SoTier")
                        .HasColumnType("int");

                    b.Property<int>("TrangThaiRong")
                        .HasColumnType("int");

                    b.HasKey("MaViTri");

                    b.HasIndex("MaBlock");

                    b.ToTable("ViTriContainers");
                });

            modelBuilder.Entity("ProjectTest.Models.Container", b =>
                {
                    b.HasOne("ProjectTest.Models.Customer", "Customer")
                        .WithMany("Containers")
                        .HasForeignKey("MaKH");

                    b.HasOne("ProjectTest.Models.ContainerType", "ContainerType")
                        .WithMany("Containers")
                        .HasForeignKey("MaLoai");

                    b.HasOne("ProjectTest.Models.ContainerExitForm", "ContainerExitForm")
                        .WithMany("Containers")
                        .HasForeignKey("MaPhieuXuat");

                    b.Navigation("ContainerExitForm");

                    b.Navigation("ContainerType");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ProjectTest.Models.ContainerEntryForm", b =>
                {
                    b.HasOne("ProjectTest.Models.Container", "Container")
                        .WithMany("ContainerEntryForms")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Container");
                });

            modelBuilder.Entity("ProjectTest.Models.DetailContainer", b =>
                {
                    b.HasOne("ProjectTest.Models.Container", "Container")
                        .WithMany("DetailContainers")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectTest.Models.ViTriContainer", "ViTriContainer")
                        .WithMany("DetailContainers")
                        .HasForeignKey("MaViTri")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Container");

                    b.Navigation("ViTriContainer");
                });

            modelBuilder.Entity("ProjectTest.Models.UserAccount", b =>
                {
                    b.HasOne("ProjectTest.Models.Customer", "Customer")
                        .WithMany("UserAccounts")
                        .HasForeignKey("MaKH");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ProjectTest.Models.ViTriContainer", b =>
                {
                    b.HasOne("ProjectTest.Models.Block", "Blocks")
                        .WithMany("viTriContainers")
                        .HasForeignKey("MaBlock");

                    b.Navigation("Blocks");
                });

            modelBuilder.Entity("ProjectTest.Models.Block", b =>
                {
                    b.Navigation("viTriContainers");
                });

            modelBuilder.Entity("ProjectTest.Models.Container", b =>
                {
                    b.Navigation("ContainerEntryForms");

                    b.Navigation("DetailContainers");
                });

            modelBuilder.Entity("ProjectTest.Models.ContainerExitForm", b =>
                {
                    b.Navigation("Containers");
                });

            modelBuilder.Entity("ProjectTest.Models.ContainerType", b =>
                {
                    b.Navigation("Containers");
                });

            modelBuilder.Entity("ProjectTest.Models.Customer", b =>
                {
                    b.Navigation("Containers");

                    b.Navigation("UserAccounts");
                });

            modelBuilder.Entity("ProjectTest.Models.ViTriContainer", b =>
                {
                    b.Navigation("DetailContainers");
                });
#pragma warning restore 612, 618
        }
    }
}