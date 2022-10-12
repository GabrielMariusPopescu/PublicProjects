using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Server.Migrations
{
    public partial class ImageNameToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Vehicles");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                value: "7ed8a021-15ba-4cd1-abae-aa1f5e988272");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FE8F0D0D-E180-4C7E-B9DC-FD13576C1FB8",
                column: "ConcurrencyStamp",
                value: "6a4a98e8-9805-4997-b16f-feb947f9a45d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6565AAA9-8B95-447A-9540-BEEAB3A8A0F1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a749c5eb-6b1a-4451-a6a2-6a4586e03998", "AQAAAAEAACcQAAAAECDTgJP+zgfsFWvqpzJ0r/a8QQDFY6Rj61BQo0MWl3ywUl0WIiTMjNBxAx4iZpJ/HQ==", "a1bde495-431c-4a26-ac7b-ca74e40076c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99B7485A-20E0-4F16-8865-7112C035746C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24f2f070-ee8b-4ab6-b500-394b17f147ad", "AQAAAAEAACcQAAAAEGyAoOEaDUHrRbKcXxqhiiA/pnajwbzmx+DJAlag2OfVnlsjE6YuKEb4UlG/ur/cBw==", "65d22af4-d12d-4ef4-ae4a-d6d281754562" });
        }
    }
}
