using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Server.Migrations
{
    public partial class AddValidationToModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "781624CC-A913-4F96-9E71-5E2B95E0C05F",
                column: "ConcurrencyStamp",
                value: "f8864ce4-a238-414e-ba22-c74b81466a18");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FE8F0D0D-E180-4C7E-B9DC-FD13576C1FB8",
                column: "ConcurrencyStamp",
                value: "1a145164-40a3-4966-a7c2-9bc00bda2ad8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6565AAA9-8B95-447A-9540-BEEAB3A8A0F1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f92062a1-110c-4c00-b275-004e37939084", "AQAAAAEAACcQAAAAEI2ANiYzmXngY+edMsDiy5d+b9xnObZ0/+lNtEoQpyfdV6jQBh37xkvHXR+y9VsMiA==", "c29abaf2-0354-4c2d-bbc9-e992e0df6465" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99B7485A-20E0-4F16-8865-7112C035746C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cc86898-e80a-49ea-a9fd-a5ff68576cc0", "AQAAAAEAACcQAAAAEPP80qcauIVGdXEE2mreaC1rXoHynKzy0sqzdP7XEMKVrek3NATY35FnD/MoCveECg==", "8fad1f02-0eaa-4411-b48c-fc1742412ba6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Models",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Colors",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "781624CC-A913-4F96-9E71-5E2B95E0C05F",
                column: "ConcurrencyStamp",
                value: "9ef3bcd9-33dc-409e-8b7a-bdbb51459ff9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FE8F0D0D-E180-4C7E-B9DC-FD13576C1FB8",
                column: "ConcurrencyStamp",
                value: "588ab05f-b3a8-46c5-888f-36b9d2067cb6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6565AAA9-8B95-447A-9540-BEEAB3A8A0F1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b024830-6df9-48a9-9132-5c4b3c2ef2ac", "AQAAAAEAACcQAAAAECbrQjpP73j2lvdSXnJOuNgcFD02uAuXWmYUCYU9rb1U9hLWIT1C5V1kUsPBSkGkkw==", "60ea2e84-c87d-4f21-836e-27da530c859d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99B7485A-20E0-4F16-8865-7112C035746C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a39aab01-b29e-4bfb-8d6a-b6a5e0c3b146", "AQAAAAEAACcQAAAAEJrV3q73bGm5k0Hw/BKKd+L5PoCD0xhNqcg6xGjL2HhRbsi/wcrdmY/hWy7kK2okpA==", "997e9416-fd4d-454e-b4ba-76d54f317904" });
        }
    }
}
