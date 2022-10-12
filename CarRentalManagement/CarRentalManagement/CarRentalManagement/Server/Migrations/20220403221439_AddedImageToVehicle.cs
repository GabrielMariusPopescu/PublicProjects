using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Server.Migrations
{
    public partial class AddedImageToVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "781624CC-A913-4F96-9E71-5E2B95E0C05F",
                column: "ConcurrencyStamp",
                value: "35b535fc-4358-44b7-9e75-9c6bdb2983a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FE8F0D0D-E180-4C7E-B9DC-FD13576C1FB8",
                column: "ConcurrencyStamp",
                value: "54ae635b-461f-46db-8cf2-22ac48b24d61");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6565AAA9-8B95-447A-9540-BEEAB3A8A0F1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4f406af-00d9-47d6-9427-48a09f8438c9", "AQAAAAEAACcQAAAAEG5+U9c0cMwCWtnRhkb08wd3FzwaGEyCu2CnjlTpT5npWdSB6vpMTspkz3OJK1m/Qw==", "6560e65d-256d-419a-943d-f2f1c7e5abb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99B7485A-20E0-4F16-8865-7112C035746C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea623193-c65b-4f5d-bd84-a0b1da20e545", "AQAAAAEAACcQAAAAEB75mgSeFk6swISb5yZnD9SVMM61qaZwiUQ8xeoru6KvqAZn1PdxzJjnTKh99AxlIg==", "54507833-9519-4555-93a4-559bc34c8377" });
        }
    }
}
