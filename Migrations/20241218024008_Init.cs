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
                name: "blocks",
                columns: table => new
                {
                    MABLOCK = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    LOAIBAY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blocks", x => x.MABLOCK);
                });

            migrationBuilder.CreateTable(
                name: "khachHangs",
                columns: table => new
                {
                    MAKH = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    TENKH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MST = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khachHangs", x => x.MAKH);
                });

            migrationBuilder.CreateTable(
                name: "loaiContainers",
                columns: table => new
                {
                    MALOAI = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    TENLOAI = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaiContainers", x => x.MALOAI);
                });

            migrationBuilder.CreateTable(
                name: "pHIEUXUATs",
                columns: table => new
                {
                    MAPHIEUXUAT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NGAYLAMPHIEU = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DONVIVANCHUYEN = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MASODONVIVANCHUYEN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TRANGTHAIDUYET = table.Column<int>(type: "int", nullable: false),
                    NGAYXUAT = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pHIEUXUATs", x => x.MAPHIEUXUAT);
                });

            migrationBuilder.CreateTable(
                name: "ViTriContainers",
                columns: table => new
                {
                    MAVITRI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MABLOCK = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SOBAY = table.Column<int>(type: "int", nullable: false),
                    SOROW = table.Column<int>(type: "int", nullable: false),
                    SOTIER = table.Column<int>(type: "int", nullable: false),
                    TRANGTHAIRONG = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTriContainers", x => x.MAVITRI);
                    table.ForeignKey(
                        name: "FK_ViTriContainers_blocks_MABLOCK",
                        column: x => x.MABLOCK,
                        principalTable: "blocks",
                        principalColumn: "MABLOCK");
                });

            migrationBuilder.CreateTable(
                name: "containers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MACONTAINER = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NUMCONTAINER = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    MALOAI = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    MAKH = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    ISOCODE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    MAPHIEUXUAT = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false),
                    MAXWEIGHT = table.Column<int>(type: "int", nullable: false),
                    TAREWEIGHT = table.Column<int>(type: "int", nullable: false),
                    NGAYSANXUAT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TINHTRANG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_containers", x => x.id);
                    table.ForeignKey(
                        name: "FK_containers_khachHangs_MAKH",
                        column: x => x.MAKH,
                        principalTable: "khachHangs",
                        principalColumn: "MAKH");
                    table.ForeignKey(
                        name: "FK_containers_loaiContainers_MALOAI",
                        column: x => x.MALOAI,
                        principalTable: "loaiContainers",
                        principalColumn: "MALOAI");
                    table.ForeignKey(
                        name: "FK_containers_pHIEUXUATs_MAPHIEUXUAT",
                        column: x => x.MAPHIEUXUAT,
                        principalTable: "pHIEUXUATs",
                        principalColumn: "MAPHIEUXUAT");
                });

            migrationBuilder.CreateTable(
                name: "cT_Containers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    MAVITRI = table.Column<int>(type: "int", nullable: false),
                    THOIGIANBATDAU = table.Column<DateTime>(type: "datetime2", nullable: false),
                    THOIGIANKETTHUC = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cT_Containers", x => new { x.id, x.MAVITRI });
                    table.ForeignKey(
                        name: "FK_cT_Containers_ViTriContainers_MAVITRI",
                        column: x => x.MAVITRI,
                        principalTable: "ViTriContainers",
                        principalColumn: "MAVITRI",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cT_Containers_containers_id",
                        column: x => x.id,
                        principalTable: "containers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "phieuNhaps",
                columns: table => new
                {
                    MAPHIEUNHAP = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NGAYDK = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NGAYGIAOCONTAINER = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TRANGTHAIDUYET = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    DONVIVANCHUYEN = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BIENSODONVIVANCHUYEN = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieuNhaps", x => x.MAPHIEUNHAP);
                    table.ForeignKey(
                        name: "FK_phieuNhaps_containers_id",
                        column: x => x.id,
                        principalTable: "containers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_containers_MAKH",
                table: "containers",
                column: "MAKH");

            migrationBuilder.CreateIndex(
                name: "IX_containers_MALOAI",
                table: "containers",
                column: "MALOAI");

            migrationBuilder.CreateIndex(
                name: "IX_containers_MAPHIEUXUAT",
                table: "containers",
                column: "MAPHIEUXUAT");

            migrationBuilder.CreateIndex(
                name: "IX_cT_Containers_MAVITRI",
                table: "cT_Containers",
                column: "MAVITRI");

            migrationBuilder.CreateIndex(
                name: "IX_phieuNhaps_id",
                table: "phieuNhaps",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_ViTriContainers_MABLOCK",
                table: "ViTriContainers",
                column: "MABLOCK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cT_Containers");

            migrationBuilder.DropTable(
                name: "phieuNhaps");

            migrationBuilder.DropTable(
                name: "ViTriContainers");

            migrationBuilder.DropTable(
                name: "containers");

            migrationBuilder.DropTable(
                name: "blocks");

            migrationBuilder.DropTable(
                name: "khachHangs");

            migrationBuilder.DropTable(
                name: "loaiContainers");

            migrationBuilder.DropTable(
                name: "pHIEUXUATs");
        }
    }
}
