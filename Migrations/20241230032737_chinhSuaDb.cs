using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTest.Migrations
{
    /// <inheritdoc />
    public partial class chinhSuaDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_MaKH",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerDetails_ViTriContainers_MaViTri",
                table: "ContainerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_ContainerExitForms_MaPhieuXuat",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_ContainerTypes_MaLoai",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Customers_MaKH",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "NgayLamPhieu",
                table: "ContainerExitForms");

            migrationBuilder.RenameColumn(
                name: "TrangThaiRong",
                table: "ViTriContainers",
                newName: "TierLocation");

            migrationBuilder.RenameColumn(
                name: "SoTier",
                table: "ViTriContainers",
                newName: "RowLocation");

            migrationBuilder.RenameColumn(
                name: "SoRow",
                table: "ViTriContainers",
                newName: "LocationSatus");

            migrationBuilder.RenameColumn(
                name: "SoBay",
                table: "ViTriContainers",
                newName: "BayLocation");

            migrationBuilder.RenameColumn(
                name: "MaViTri",
                table: "ViTriContainers",
                newName: "IdLoctation");

            migrationBuilder.RenameColumn(
                name: "TenKH",
                table: "Customers",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "Sdt",
                table: "Customers",
                newName: "CustomerPhone");

            migrationBuilder.RenameColumn(
                name: "Mst",
                table: "Customers",
                newName: "TaxCode");

            migrationBuilder.RenameColumn(
                name: "MaKH",
                table: "Customers",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "TenLoai",
                table: "ContainerTypes",
                newName: "NameTypeContainer");

            migrationBuilder.RenameColumn(
                name: "MaLoai",
                table: "ContainerTypes",
                newName: "IdTypeContainer");

            migrationBuilder.RenameColumn(
                name: "TinhTrang",
                table: "Containers",
                newName: "ContainerStatus");

            migrationBuilder.RenameColumn(
                name: "NgaySanXuat",
                table: "Containers",
                newName: "DateOfManufacture");

            migrationBuilder.RenameColumn(
                name: "MaPhieuXuat",
                table: "Containers",
                newName: "IdExitForm");

            migrationBuilder.RenameColumn(
                name: "MaLoai",
                table: "Containers",
                newName: "IdTypeContainer");

            migrationBuilder.RenameColumn(
                name: "MaKH",
                table: "Containers",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "MaContainer",
                table: "Containers",
                newName: "SeriContainer");

            migrationBuilder.RenameIndex(
                name: "IX_Containers_MaPhieuXuat",
                table: "Containers",
                newName: "IX_Containers_IdExitForm");

            migrationBuilder.RenameIndex(
                name: "IX_Containers_MaLoai",
                table: "Containers",
                newName: "IX_Containers_IdTypeContainer");

            migrationBuilder.RenameIndex(
                name: "IX_Containers_MaKH",
                table: "Containers",
                newName: "IX_Containers_IdCustomer");

            migrationBuilder.RenameColumn(
                name: "TrangThaiDuyet",
                table: "ContainerExitForms",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "NgayXuat",
                table: "ContainerExitForms",
                newName: "DateOfRegistration");

            migrationBuilder.RenameColumn(
                name: "MaSoDonViVanChuyen",
                table: "ContainerExitForms",
                newName: "TransportExitLincese");

            migrationBuilder.RenameColumn(
                name: "DonViVanChuyen",
                table: "ContainerExitForms",
                newName: "TransportType");

            migrationBuilder.RenameColumn(
                name: "MaPhieuXuat",
                table: "ContainerExitForms",
                newName: "IdExitForm");

            migrationBuilder.RenameColumn(
                name: "TrangThaiDuyet",
                table: "ContainerEntryForms",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "NgayGiaoContainer",
                table: "ContainerEntryForms",
                newName: "DateRegistered");

            migrationBuilder.RenameColumn(
                name: "NgayDK",
                table: "ContainerEntryForms",
                newName: "DateOfEntryContainer");

            migrationBuilder.RenameColumn(
                name: "DonViVanChuyen",
                table: "ContainerEntryForms",
                newName: "TransportEntryType");

            migrationBuilder.RenameColumn(
                name: "BienSoDonViVanChuyen",
                table: "ContainerEntryForms",
                newName: "TransportEntryLicense");

            migrationBuilder.RenameColumn(
                name: "MaPhieuNhap",
                table: "ContainerEntryForms",
                newName: "IdEntryForm");

            migrationBuilder.RenameColumn(
                name: "ThoiGianKetThuc",
                table: "ContainerDetails",
                newName: "TimeEnd");

            migrationBuilder.RenameColumn(
                name: "ThoiGianBatDau",
                table: "ContainerDetails",
                newName: "TimeBegin");

            migrationBuilder.RenameColumn(
                name: "MaViTri",
                table: "ContainerDetails",
                newName: "IdLoctation");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerDetails_MaViTri",
                table: "ContainerDetails",
                newName: "IX_ContainerDetails_IdLoctation");

            migrationBuilder.RenameColumn(
                name: "LoaiBay",
                table: "Blocks",
                newName: "BayType");

            migrationBuilder.RenameColumn(
                name: "MaBlock",
                table: "Blocks",
                newName: "IdBlock");

            migrationBuilder.RenameColumn(
                name: "MaNv",
                table: "Accounts",
                newName: "IdStaff");

            migrationBuilder.RenameColumn(
                name: "MaKH",
                table: "Accounts",
                newName: "IdCustomer");

            migrationBuilder.RenameColumn(
                name: "LoaiAccount",
                table: "Accounts",
                newName: "AccountType");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_MaKH",
                table: "Accounts",
                newName: "IX_Accounts_IdCustomer");

            migrationBuilder.AddColumn<string>(
                name: "IdBlock",
                table: "ViTriContainers",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfExitContainer",
                table: "ContainerExitForms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ContainerEntryFormListDto",
                columns: table => new
                {
                    IdEntryForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEntryRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfEntryContainer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ContainerExitFormListDto",
                columns: table => new
                {
                    IdExitForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfExitRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfExitContainer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ContainerListDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdContainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumContainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEntryContainer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfExitContainer = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ContainerListExitDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdExitForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfExitContainer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdContainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    TypeContainerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TranportExitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportExitLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEntryContainer = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ContainerListOfCustomerInSnpDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdContainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeContainerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    DateOfEntryContainer = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_IdCustomer",
                table: "Accounts",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerDetails_ViTriContainers_IdLoctation",
                table: "ContainerDetails",
                column: "IdLoctation",
                principalTable: "ViTriContainers",
                principalColumn: "IdLoctation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_ContainerExitForms_IdExitForm",
                table: "Containers",
                column: "IdExitForm",
                principalTable: "ContainerExitForms",
                principalColumn: "IdExitForm");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_ContainerTypes_IdTypeContainer",
                table: "Containers",
                column: "IdTypeContainer",
                principalTable: "ContainerTypes",
                principalColumn: "IdTypeContainer");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Customers_IdCustomer",
                table: "Containers",
                column: "IdCustomer",
                principalTable: "Customers",
                principalColumn: "IdCustomer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_IdCustomer",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerDetails_ViTriContainers_IdLoctation",
                table: "ContainerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_ContainerExitForms_IdExitForm",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_ContainerTypes_IdTypeContainer",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Customers_IdCustomer",
                table: "Containers");

            migrationBuilder.DropTable(
                name: "ContainerEntryFormListDto");

            migrationBuilder.DropTable(
                name: "ContainerExitFormListDto");

            migrationBuilder.DropTable(
                name: "ContainerListDto");

            migrationBuilder.DropTable(
                name: "ContainerListExitDto");

            migrationBuilder.DropTable(
                name: "ContainerListOfCustomerInSnpDto");

            migrationBuilder.DropColumn(
                name: "IdBlock",
                table: "ViTriContainers");

            migrationBuilder.DropColumn(
                name: "DateOfExitContainer",
                table: "ContainerExitForms");

            migrationBuilder.RenameColumn(
                name: "TierLocation",
                table: "ViTriContainers",
                newName: "TrangThaiRong");

            migrationBuilder.RenameColumn(
                name: "RowLocation",
                table: "ViTriContainers",
                newName: "SoTier");

            migrationBuilder.RenameColumn(
                name: "LocationSatus",
                table: "ViTriContainers",
                newName: "SoRow");

            migrationBuilder.RenameColumn(
                name: "BayLocation",
                table: "ViTriContainers",
                newName: "SoBay");

            migrationBuilder.RenameColumn(
                name: "IdLoctation",
                table: "ViTriContainers",
                newName: "MaViTri");

            migrationBuilder.RenameColumn(
                name: "TaxCode",
                table: "Customers",
                newName: "Mst");

            migrationBuilder.RenameColumn(
                name: "CustomerPhone",
                table: "Customers",
                newName: "Sdt");

            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Customers",
                newName: "TenKH");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "Customers",
                newName: "MaKH");

            migrationBuilder.RenameColumn(
                name: "NameTypeContainer",
                table: "ContainerTypes",
                newName: "TenLoai");

            migrationBuilder.RenameColumn(
                name: "IdTypeContainer",
                table: "ContainerTypes",
                newName: "MaLoai");

            migrationBuilder.RenameColumn(
                name: "SeriContainer",
                table: "Containers",
                newName: "MaContainer");

            migrationBuilder.RenameColumn(
                name: "IdTypeContainer",
                table: "Containers",
                newName: "MaLoai");

            migrationBuilder.RenameColumn(
                name: "IdExitForm",
                table: "Containers",
                newName: "MaPhieuXuat");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "Containers",
                newName: "MaKH");

            migrationBuilder.RenameColumn(
                name: "DateOfManufacture",
                table: "Containers",
                newName: "NgaySanXuat");

            migrationBuilder.RenameColumn(
                name: "ContainerStatus",
                table: "Containers",
                newName: "TinhTrang");

            migrationBuilder.RenameIndex(
                name: "IX_Containers_IdTypeContainer",
                table: "Containers",
                newName: "IX_Containers_MaLoai");

            migrationBuilder.RenameIndex(
                name: "IX_Containers_IdExitForm",
                table: "Containers",
                newName: "IX_Containers_MaPhieuXuat");

            migrationBuilder.RenameIndex(
                name: "IX_Containers_IdCustomer",
                table: "Containers",
                newName: "IX_Containers_MaKH");

            migrationBuilder.RenameColumn(
                name: "TransportType",
                table: "ContainerExitForms",
                newName: "DonViVanChuyen");

            migrationBuilder.RenameColumn(
                name: "TransportExitLincese",
                table: "ContainerExitForms",
                newName: "MaSoDonViVanChuyen");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ContainerExitForms",
                newName: "TrangThaiDuyet");

            migrationBuilder.RenameColumn(
                name: "DateOfRegistration",
                table: "ContainerExitForms",
                newName: "NgayXuat");

            migrationBuilder.RenameColumn(
                name: "IdExitForm",
                table: "ContainerExitForms",
                newName: "MaPhieuXuat");

            migrationBuilder.RenameColumn(
                name: "TransportEntryType",
                table: "ContainerEntryForms",
                newName: "DonViVanChuyen");

            migrationBuilder.RenameColumn(
                name: "TransportEntryLicense",
                table: "ContainerEntryForms",
                newName: "BienSoDonViVanChuyen");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ContainerEntryForms",
                newName: "TrangThaiDuyet");

            migrationBuilder.RenameColumn(
                name: "DateRegistered",
                table: "ContainerEntryForms",
                newName: "NgayGiaoContainer");

            migrationBuilder.RenameColumn(
                name: "DateOfEntryContainer",
                table: "ContainerEntryForms",
                newName: "NgayDK");

            migrationBuilder.RenameColumn(
                name: "IdEntryForm",
                table: "ContainerEntryForms",
                newName: "MaPhieuNhap");

            migrationBuilder.RenameColumn(
                name: "TimeEnd",
                table: "ContainerDetails",
                newName: "ThoiGianKetThuc");

            migrationBuilder.RenameColumn(
                name: "TimeBegin",
                table: "ContainerDetails",
                newName: "ThoiGianBatDau");

            migrationBuilder.RenameColumn(
                name: "IdLoctation",
                table: "ContainerDetails",
                newName: "MaViTri");

            migrationBuilder.RenameIndex(
                name: "IX_ContainerDetails_IdLoctation",
                table: "ContainerDetails",
                newName: "IX_ContainerDetails_MaViTri");

            migrationBuilder.RenameColumn(
                name: "BayType",
                table: "Blocks",
                newName: "LoaiBay");

            migrationBuilder.RenameColumn(
                name: "IdBlock",
                table: "Blocks",
                newName: "MaBlock");

            migrationBuilder.RenameColumn(
                name: "IdStaff",
                table: "Accounts",
                newName: "MaNv");

            migrationBuilder.RenameColumn(
                name: "IdCustomer",
                table: "Accounts",
                newName: "MaKH");

            migrationBuilder.RenameColumn(
                name: "AccountType",
                table: "Accounts",
                newName: "LoaiAccount");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_IdCustomer",
                table: "Accounts",
                newName: "IX_Accounts_MaKH");

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayLamPhieu",
                table: "ContainerExitForms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_MaKH",
                table: "Accounts",
                column: "MaKH",
                principalTable: "Customers",
                principalColumn: "MaKH");

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerDetails_ViTriContainers_MaViTri",
                table: "ContainerDetails",
                column: "MaViTri",
                principalTable: "ViTriContainers",
                principalColumn: "MaViTri",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_ContainerExitForms_MaPhieuXuat",
                table: "Containers",
                column: "MaPhieuXuat",
                principalTable: "ContainerExitForms",
                principalColumn: "MaPhieuXuat");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_ContainerTypes_MaLoai",
                table: "Containers",
                column: "MaLoai",
                principalTable: "ContainerTypes",
                principalColumn: "MaLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Customers_MaKH",
                table: "Containers",
                column: "MaKH",
                principalTable: "Customers",
                principalColumn: "MaKH");
        }
    }
}
