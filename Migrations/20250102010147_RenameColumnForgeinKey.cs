using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTest.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnForgeinKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContainerDetails_ViTriContainers_IdLoctation",
                table: "ContainerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ViTriContainers_Blocks_MaBlock",
                table: "ViTriContainers");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_ViTriContainers",
                table: "ViTriContainers");

            migrationBuilder.DropIndex(
                name: "IX_ViTriContainers_MaBlock",
                table: "ViTriContainers");

            migrationBuilder.DropColumn(
                name: "MaBlock",
                table: "ViTriContainers");

            migrationBuilder.RenameTable(
                name: "ViTriContainers",
                newName: "ContainerLocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContainerLocations",
                table: "ContainerLocations",
                column: "IdLoctation");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerLocations_IdBlock",
                table: "ContainerLocations",
                column: "IdBlock");

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerDetails_ContainerLocations_IdLoctation",
                table: "ContainerDetails",
                column: "IdLoctation",
                principalTable: "ContainerLocations",
                principalColumn: "IdLoctation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerLocations_Blocks_IdBlock",
                table: "ContainerLocations",
                column: "IdBlock",
                principalTable: "Blocks",
                principalColumn: "IdBlock");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContainerDetails_ContainerLocations_IdLoctation",
                table: "ContainerDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerLocations_Blocks_IdBlock",
                table: "ContainerLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContainerLocations",
                table: "ContainerLocations");

            migrationBuilder.DropIndex(
                name: "IX_ContainerLocations_IdBlock",
                table: "ContainerLocations");

            migrationBuilder.RenameTable(
                name: "ContainerLocations",
                newName: "ViTriContainers");

            migrationBuilder.AddColumn<string>(
                name: "MaBlock",
                table: "ViTriContainers",
                type: "nvarchar(1)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ViTriContainers",
                table: "ViTriContainers",
                column: "IdLoctation");

            migrationBuilder.CreateTable(
                name: "ContainerEntryFormListDto",
                columns: table => new
                {
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEntryContainer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfEntryRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdEntryForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ContainerExitFormListDto",
                columns: table => new
                {
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfExitContainer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfExitRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdExitForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ContainerListDto",
                columns: table => new
                {
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEntryContainer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfExitContainer = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdContainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumContainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ContainerListExitDto",
                columns: table => new
                {
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEntryContainer = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfExitContainer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdContainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdExitForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TranportExitType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportExitLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeContainerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ContainerListOfCustomerInSnpDto",
                columns: table => new
                {
                    DateOfEntryContainer = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdContainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    TypeContainerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_ViTriContainers_MaBlock",
                table: "ViTriContainers",
                column: "MaBlock");

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerDetails_ViTriContainers_IdLoctation",
                table: "ContainerDetails",
                column: "IdLoctation",
                principalTable: "ViTriContainers",
                principalColumn: "IdLoctation",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ViTriContainers_Blocks_MaBlock",
                table: "ViTriContainers",
                column: "MaBlock",
                principalTable: "Blocks",
                principalColumn: "IdBlock");
        }
    }
}
