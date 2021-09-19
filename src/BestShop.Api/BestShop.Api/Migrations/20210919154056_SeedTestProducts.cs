using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BestShop.Api.Migrations
{
    public partial class SeedTestProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AvailableQuantity", "Code", "Created", "Description", "HasMarkup", "Markup", "Modified", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("82b62c56-e94c-491e-aac3-1944c4e8d131"), 10, "Prod001", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(1540), "Description for Product 1", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(2514), "Product 1", 22.50m },
                    { new Guid("2e72bc2f-109a-411e-8f79-f3e3cd01a8ba"), 15, "Prod0023", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4800), "Description for Product 23", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4801), "Product 23", 500.99m },
                    { new Guid("e4402e01-3ea5-4290-a0e6-787bd184b285"), 15, "Prod0022", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4798), "Description for Product 22", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4798), "Product 22", 285.99m },
                    { new Guid("c60c638c-9587-454f-99b2-316ca188ca8b"), 15, "Prod0021", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4795), "Description for Product 21", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4796), "Product 21", 44.78m },
                    { new Guid("2e739339-d491-4d96-9684-177bf26d2517"), 15, "Prod0020", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4793), "Description for Product 20", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4793), "Product 20", 69.30m },
                    { new Guid("17764b9d-1c95-45e9-a1b0-a96c40321d06"), 15, "Prod0019", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4790), "Description for Product 19", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4791), "Product 19", 13.50m },
                    { new Guid("1060b098-f1b9-42f8-898b-358bc25ed136"), 15, "Prod0018", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4788), "Description for Product 18", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4788), "Product 18", 365.50m },
                    { new Guid("393c5ac7-26e6-4760-b2b5-75c6ccfa18d4"), 15, "Prod0017", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4784), "Description for Product 17", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4785), "Product 17", 189.50m },
                    { new Guid("a383fd3f-1756-4aa1-b8fa-849c84f826fb"), 15, "Prod0016", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4779), "Description for Product 16", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4780), "Product 16", 83.50m },
                    { new Guid("5318ae4c-5473-419e-b8e0-1784b17701bf"), 15, "Prod0015", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4777), "Description for Product 15", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4778), "Product 15", 100.50m },
                    { new Guid("2a30f745-9581-4e1a-a9d7-c44f9a6d73b8"), 15, "Prod0014", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4774), "Description for Product 14", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4775), "Product 14", 35.50m },
                    { new Guid("5c27810d-9be3-43b5-85f8-d864b512668c"), 15, "Prod0024", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4803), "Description for Product 24", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4803), "Product 24", 412.00m },
                    { new Guid("a6d3ab96-b1e5-43d4-8bdf-0d5fb71acb2d"), 15, "Prod0013", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4772), "Description for Product 13", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4773), "Product 13", 101.50m },
                    { new Guid("c8781246-2d4e-4413-a58b-a17e176da833"), 15, "Prod0011", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4767), "Description for Product 11", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4768), "Product 11", 300.59m },
                    { new Guid("c02f0eb0-aa67-4308-9231-9aae79519874"), 15, "Prod0010", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4764), "Description for Product 10", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4765), "Product 10", 265.49m },
                    { new Guid("1145d6bf-53d6-45c1-bc03-a412707cbd74"), 15, "Prod009", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4761), "Description for Product 9", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4761), "Product 9", 145.89m },
                    { new Guid("635b3127-3654-42fb-8449-1b769056fcdf"), 15, "Prod008", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4753), "Description for Product 8", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4754), "Product 8", 50.89m },
                    { new Guid("06a5a09a-3b74-40a3-8efc-ac0847680e76"), 15, "Prod007", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4750), "Description for Product 7", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4751), "Product 7", 60.00m },
                    { new Guid("da259b14-c0d6-4325-b197-2d40511cc7aa"), 15, "Prod006", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4748), "Description for Product 6", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4748), "Product 6", 40.99m },
                    { new Guid("ea4c4d78-bbd9-434b-9ff5-864eb7bf1e22"), 15, "Prod005", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4742), "Description for Product 5", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4743), "Product 5", 5.00m },
                    { new Guid("864220f7-183f-493e-8553-4fec9ddbee57"), 15, "Prod004", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4740), "Description for Product 4", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4741), "Product 4", 92.00m },
                    { new Guid("2a8b73c4-5d8b-4cc9-8a62-0db0c7d178d1"), 15, "Prod003", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4737), "Description for Product 3", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4737), "Product 3", 10.00m },
                    { new Guid("5c2d1c43-752f-43a9-b6d3-a81d423730c8"), 15, "Prod002", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4730), "Description for Product 2", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4733), "Product 2", 23.99m },
                    { new Guid("338eef83-b7a4-4a6b-a69b-659b6323f234"), 15, "Prod0012", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4769), "Description for Product 12", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4770), "Product 12", 172.59m },
                    { new Guid("f44a7f24-cf9c-4a10-bd96-72eb13ef12eb"), 15, "Prod0025", new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4807), "Description for Product 25", false, null, new DateTime(2021, 9, 19, 15, 40, 56, 424, DateTimeKind.Utc).AddTicks(4808), "Product 25", 60.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("06a5a09a-3b74-40a3-8efc-ac0847680e76"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1060b098-f1b9-42f8-898b-358bc25ed136"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1145d6bf-53d6-45c1-bc03-a412707cbd74"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("17764b9d-1c95-45e9-a1b0-a96c40321d06"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2a30f745-9581-4e1a-a9d7-c44f9a6d73b8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2a8b73c4-5d8b-4cc9-8a62-0db0c7d178d1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2e72bc2f-109a-411e-8f79-f3e3cd01a8ba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2e739339-d491-4d96-9684-177bf26d2517"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("338eef83-b7a4-4a6b-a69b-659b6323f234"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("393c5ac7-26e6-4760-b2b5-75c6ccfa18d4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5318ae4c-5473-419e-b8e0-1784b17701bf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5c27810d-9be3-43b5-85f8-d864b512668c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5c2d1c43-752f-43a9-b6d3-a81d423730c8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("635b3127-3654-42fb-8449-1b769056fcdf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("82b62c56-e94c-491e-aac3-1944c4e8d131"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("864220f7-183f-493e-8553-4fec9ddbee57"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a383fd3f-1756-4aa1-b8fa-849c84f826fb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a6d3ab96-b1e5-43d4-8bdf-0d5fb71acb2d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c02f0eb0-aa67-4308-9231-9aae79519874"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c60c638c-9587-454f-99b2-316ca188ca8b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c8781246-2d4e-4413-a58b-a17e176da833"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("da259b14-c0d6-4325-b197-2d40511cc7aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e4402e01-3ea5-4290-a0e6-787bd184b285"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ea4c4d78-bbd9-434b-9ff5-864eb7bf1e22"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f44a7f24-cf9c-4a10-bd96-72eb13ef12eb"));
        }
    }
}
