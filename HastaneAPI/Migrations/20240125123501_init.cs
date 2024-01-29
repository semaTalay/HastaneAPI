using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hastane",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaneAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hastane", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hasta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Klinik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MuayeneTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HastaneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hasta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hasta_Hastane_HastaneId",
                        column: x => x.HastaneId,
                        principalTable: "Hastane",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hastane",
                columns: new[] { "Id", "Adres", "HastaneAd" },
                values: new object[] { 1, "İstanbul", "Kartal" });

            migrationBuilder.InsertData(
                table: "Hastane",
                columns: new[] { "Id", "Adres", "HastaneAd" },
                values: new object[] { 2, "İstanbul", "Pendik" });

            migrationBuilder.InsertData(
                table: "Hasta",
                columns: new[] { "Id", "Ad", "HastaneId", "Klinik", "MuayeneTarihi", "Soyad" },
                values: new object[] { 1, "Semanur", 1, "KBB", new DateTime(2024, 1, 25, 15, 35, 1, 260, DateTimeKind.Local).AddTicks(7384), "Talay" });

            migrationBuilder.InsertData(
                table: "Hasta",
                columns: new[] { "Id", "Ad", "HastaneId", "Klinik", "MuayeneTarihi", "Soyad" },
                values: new object[] { 2, "AAA", 2, "Göz", new DateTime(2024, 1, 25, 15, 35, 1, 260, DateTimeKind.Local).AddTicks(7397), "BBB" });

            migrationBuilder.CreateIndex(
                name: "IX_Hasta_HastaneId",
                table: "Hasta",
                column: "HastaneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hasta");

            migrationBuilder.DropTable(
                name: "Hastane");
        }
    }
}
