using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo02_WebAPI.DAL.Migrations
{
    public partial class AddDataAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "author_id", "firstname", "lastname" },
                values: new object[,]
                {
                    { new Guid("6e2581bd-2227-4840-a116-db904ee67aa2"), "Riri", "Duck" },
                    { new Guid("a8392ee1-9582-4394-ba11-a085dd3b26cd"), "Della", "Duck" },
                    { new Guid("624f8d55-bd15-4c80-bf60-98da547afda7"), "Zaza", "Vanderquack" },
                    { new Guid("0ce198f0-95a3-4053-b08f-1481a91c5531"), "Gontran", "Bonheur" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: new Guid("0ce198f0-95a3-4053-b08f-1481a91c5531"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: new Guid("624f8d55-bd15-4c80-bf60-98da547afda7"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: new Guid("6e2581bd-2227-4840-a116-db904ee67aa2"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: new Guid("a8392ee1-9582-4394-ba11-a085dd3b26cd"));
        }
    }
}
