using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTest.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    MaBlock = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    LoaiBay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.MaBlock);
                });

            migrationBuilder.CreateTable(
                name: "ContainerExitForms",
                columns: table => new
                {
                    MaPhieuXuat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayLamPhieu = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DonViVanChuyen = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MaSoDonViVanChuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TrangThaiDuyet = table.Column<int>(type: "int", nullable: false),
                    NgayXuat = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerExitForms", x => x.MaPhieuXuat);
                });

            migrationBuilder.CreateTable(
                name: "ContainerTypes",
                columns: table => new
                {
                    MaLoai = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerTypes", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TenKH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Mst = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    stt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianQuery = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.stt);
                });

            migrationBuilder.CreateTable(
                name: "ViTriContainers",
                columns: table => new
                {
                    MaViTri = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaBlock = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SoBay = table.Column<int>(type: "int", nullable: false),
                    SoRow = table.Column<int>(type: "int", nullable: false),
                    SoTier = table.Column<int>(type: "int", nullable: false),
                    TrangThaiRong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTriContainers", x => x.MaViTri);
                    table.ForeignKey(
                        name: "FK_ViTriContainers_Blocks_MaBlock",
                        column: x => x.MaBlock,
                        principalTable: "Blocks",
                        principalColumn: "MaBlock");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Stt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKH = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    MaNv = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    LoaiAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Stt);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_MaKH",
                        column: x => x.MaKH,
                        principalTable: "Customers",
                        principalColumn: "MaKH");
                });

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaContainer = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NumContainer = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MaLoai = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    MaKH = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    IsoCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MaPhieuXuat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false),
                    TareWeight = table.Column<int>(type: "int", nullable: false),
                    NgaySanXuat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Containers_ContainerExitForms_MaPhieuXuat",
                        column: x => x.MaPhieuXuat,
                        principalTable: "ContainerExitForms",
                        principalColumn: "MaPhieuXuat");
                    table.ForeignKey(
                        name: "FK_Containers_ContainerTypes_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "ContainerTypes",
                        principalColumn: "MaLoai");
                    table.ForeignKey(
                        name: "FK_Containers_Customers_MaKH",
                        column: x => x.MaKH,
                        principalTable: "Customers",
                        principalColumn: "MaKH");
                });

            migrationBuilder.CreateTable(
                name: "ContainerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MaViTri = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerDetails", x => new { x.Id, x.MaViTri });
                    table.ForeignKey(
                        name: "FK_ContainerDetails_Containers_Id",
                        column: x => x.Id,
                        principalTable: "Containers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContainerDetails_ViTriContainers_MaViTri",
                        column: x => x.MaViTri,
                        principalTable: "ViTriContainers",
                        principalColumn: "MaViTri",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContainerEntryForms",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NgayDK = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayGiaoContainer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThaiDuyet = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    DonViVanChuyen = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    BienSoDonViVanChuyen = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerEntryForms", x => x.MaPhieuNhap);
                    table.ForeignKey(
                        name: "FK_ContainerEntryForms_Containers_Id",
                        column: x => x.Id,
                        principalTable: "Containers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_MaKH",
                table: "Accounts",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerDetails_MaViTri",
                table: "ContainerDetails",
                column: "MaViTri");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerEntryForms_Id",
                table: "ContainerEntryForms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_MaKH",
                table: "Containers",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_MaLoai",
                table: "Containers",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_MaPhieuXuat",
                table: "Containers",
                column: "MaPhieuXuat");

            migrationBuilder.CreateIndex(
                name: "IX_ViTriContainers_MaBlock",
                table: "ViTriContainers",
                column: "MaBlock");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "ContainerDetails");

            migrationBuilder.DropTable(
                name: "ContainerEntryForms");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "ViTriContainers");

            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "ContainerExitForms");

            migrationBuilder.DropTable(
                name: "ContainerTypes");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
