using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo02_WebAPI.DAL.Migrations
{
    public partial class AddDataBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "author_id", "firstname", "lastname" },
                values: new object[,]
                {
                    { new Guid("4500f329-e046-4395-b532-fe734b9bd637"), "Riri", "Duck" },
                    { new Guid("8dc71cc2-bfaf-4792-bbc0-9a3fd6ad9e22"), "Della", "Duck" },
                    { new Guid("b3a11a9f-c717-4984-bd69-2f4e4f880b16"), "Zaza", "Vanderquack" },
                    { new Guid("08539e80-348d-4dd4-b64d-f31259f39353"), "Gontran", "Bonheur" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "book_id", "nb_page", "title" },
                values: new object[,]
                {
                    { new Guid("528b0102-c701-421a-84b6-b3bcb7973cd5"), (short)42, "Hello World" },
                    { new Guid("4685f5aa-9b4d-4160-86f6-6b86ddd2f168"), null, "Bonjour" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsAuthorId", "BooksBookId" },
                values: new object[] { new Guid("4500f329-e046-4395-b532-fe734b9bd637"), new Guid("528b0102-c701-421a-84b6-b3bcb7973cd5") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { new Guid("4500f329-e046-4395-b532-fe734b9bd637"), new Guid("528b0102-c701-421a-84b6-b3bcb7973cd5") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: new Guid("08539e80-348d-4dd4-b64d-f31259f39353"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: new Guid("8dc71cc2-bfaf-4792-bbc0-9a3fd6ad9e22"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: new Guid("b3a11a9f-c717-4984-bd69-2f4e4f880b16"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: new Guid("4685f5aa-9b4d-4160-86f6-6b86ddd2f168"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: new Guid("4500f329-e046-4395-b532-fe734b9bd637"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: new Guid("528b0102-c701-421a-84b6-b3bcb7973cd5"));

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
    }
}
