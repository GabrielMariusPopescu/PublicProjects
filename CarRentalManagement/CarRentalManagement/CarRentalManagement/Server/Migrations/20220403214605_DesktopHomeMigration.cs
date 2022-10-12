using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Server.Migrations
{
    public partial class DesktopHomeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
