using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Server.Migrations
{
    public partial class AddedImageToVehicle2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Customers");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Vehicles",
                type: "varbinary(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Vehicles");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Customers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "781624CC-A913-4F96-9E71-5E2B95E0C05F",
                column: "ConcurrencyStamp",
                value: "1f4cbd62-2bb8-4cdf-b7c5-40e2a5beba57");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FE8F0D0D-E180-4C7E-B9DC-FD13576C1FB8",
                column: "ConcurrencyStamp",
                value: "d1b37a95-6cb9-4f81-97b2-635ebbe5d1d5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6565AAA9-8B95-447A-9540-BEEAB3A8A0F1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77ff3ad1-8871-4ef3-a9eb-556cd32f359d", "AQAAAAEAACcQAAAAEEvVAjGAvIdx24x1XLkqP2wQ0C/TTIcnjua1nwkvmISgSP8EGzqLvPodctGO1st0ig==", "df66a06b-d1da-4a86-89aa-a66122f56f3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99B7485A-20E0-4F16-8865-7112C035746C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "969a926b-e1ad-4f31-be12-327a2255adf4", "AQAAAAEAACcQAAAAEMFVAhNbzDoATq1kimn4MUfMeQxYYxZVWdAEMW7JDrIMB7IpF0vnppR1lQLlba1s6Q==", "820b1791-8d17-42f8-b416-a5da7ae918b6" });
        }
    }
}
