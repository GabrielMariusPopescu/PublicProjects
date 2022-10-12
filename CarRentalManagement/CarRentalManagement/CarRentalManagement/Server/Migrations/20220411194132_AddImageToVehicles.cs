using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Server.Migrations
{
    public partial class AddImageToVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "781624CC-A913-4F96-9E71-5E2B95E0C05F",
                column: "ConcurrencyStamp",
                value: "43fec536-8500-483b-803b-a9fb98f7c8eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FE8F0D0D-E180-4C7E-B9DC-FD13576C1FB8",
                column: "ConcurrencyStamp",
                value: "9a90082b-57f9-47a6-bd31-8c5d2c4b7765");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6565AAA9-8B95-447A-9540-BEEAB3A8A0F1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99e30b39-41ef-49ea-a9d4-b9f25aa5a9df", "AQAAAAEAACcQAAAAEHJFSVIpVAUFwpMYQfWmJBVzfW/V6RS2l2tRdS4JvcbXdMfvmGH4hhsnrOEgNyANpQ==", "71605d9a-b38d-4c93-aa34-321e928066b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99B7485A-20E0-4F16-8865-7112C035746C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b1a4b85-5e36-4a2c-9467-8893b22c4cde", "AQAAAAEAACcQAAAAEBcAdgGitfVMg+DoCkZvgFflJx8l40A5nWJkRLnWN3VVem49EkCUNZJfhpkoGh55cg==", "ffe3227c-a7ba-46c9-b971-d8d19fd01792" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Vehicles");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Vehicles",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "781624CC-A913-4F96-9E71-5E2B95E0C05F",
                column: "ConcurrencyStamp",
                value: "703d6ffd-a373-4936-ba5d-956a06a7b478");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FE8F0D0D-E180-4C7E-B9DC-FD13576C1FB8",
                column: "ConcurrencyStamp",
                value: "638fc4bd-f8c8-4508-b4bf-aa092b0657ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6565AAA9-8B95-447A-9540-BEEAB3A8A0F1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "183e1171-51d7-463e-83d4-7f7c8e33f432", "AQAAAAEAACcQAAAAEELl0dqeXCTDniecsegnLW8vtPTGMg1pdLO5fQ4gLlTQS7w3FJ+NKAeYyeAmcDb3MQ==", "8d78201b-cbd1-4212-b2e5-23629b57add7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99B7485A-20E0-4F16-8865-7112C035746C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88dd446d-3322-4d89-b86c-8b20c6aa0862", "AQAAAAEAACcQAAAAEL1jjdWkswaCb9KcbdPPAcbU/Wf7X+xomcQ5vLlaeioYhC/MvG/zQi/V23YodIbF+w==", "ae2ec9c5-917c-4ba1-8c6c-db0f249adff3" });
        }
    }
}
