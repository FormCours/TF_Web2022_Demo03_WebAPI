using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo02_WebAPI.DAL.Migrations
{
    public partial class AddDataBook2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("4a0effdc-5290-4bbd-906f-0bad015bd83c"), "Riri", "Duck" },
                    { new Guid("b6d536e9-afb3-40c7-9e87-14144eaae072"), "Della", "Duck" },
                    { new Guid("bf04a921-d509-4708-bbea-ae48a37fc953"), "Zaza", "Vanderquack" },
                    { new Guid("d397228d-3c0b-424e-bfa6-7ea98495125e"), "Gontran", "Bonheur" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "book_id", "nb_page", "title" },
                values: new object[,]
                {
                    { new Guid("0a2ddeef-5121-4d4f-b866-4dcfeaad4a8c"), (short)42, "Hello World" },
                    { new Guid("15429365-7ecd-497f-8889-63d732be0dd9"), null, "Bonjour" }
                });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsAuthorId", "BooksBookId" },
                values: new object[] { new Guid("4a0effdc-5290-4bbd-906f-0bad015bd83c"), new Guid("0a2ddeef-5121-4d4f-b866-4dcfeaad4a8c") });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsAuthorId", "BooksBookId" },
                values: new object[] { new Guid("b6d536e9-afb3-40c7-9e87-14144eaae072"), new Guid("15429365-7ecd-497f-8889-63d732be0dd9") });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsAuthorId", "BooksBookId" },
                values: new object[] { new Guid("bf04a921-d509-4708-bbea-ae48a37fc953"), new Guid("15429365-7ecd-497f-8889-63d732be0dd9") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { new Guid("4a0effdc-5290-4bbd-906f-0bad015bd83c"), new Guid("0a2ddeef-5121-4d4f-b866-4dcfeaad4a8c") });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { new Guid("b6d536e9-afb3-40c7-9e87-14144eaae072"), new Guid("15429365-7ecd-497f-8889-63d732be0dd9") });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { new Guid("bf04a921-d509-4708-bbea-ae48a37fc953"), new Guid("15429365-7ecd-497f-8889-63d732be0dd9") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: new Guid("d397228d-3c0b-424e-bfa6-7ea98495125e"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: new Guid("4a0effdc-5290-4bbd-906f-0bad015bd83c"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: new Guid("b6d536e9-afb3-40c7-9e87-14144eaae072"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "author_id",
                keyValue: new Guid("bf04a921-d509-4708-bbea-ae48a37fc953"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: new Guid("0a2ddeef-5121-4d4f-b866-4dcfeaad4a8c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "book_id",
                keyValue: new Guid("15429365-7ecd-497f-8889-63d732be0dd9"));

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
    }
}
