using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement.Server.Migrations
{
    public partial class AddImageToVehicles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "781624CC-A913-4F96-9E71-5E2B95E0C05F",
                column: "ConcurrencyStamp",
                value: "55348555-119e-4cb6-b654-da3a53b90254");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "FE8F0D0D-E180-4C7E-B9DC-FD13576C1FB8",
                column: "ConcurrencyStamp",
                value: "cd19e9f7-fbaa-43ec-96bf-d74b264bda7d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6565AAA9-8B95-447A-9540-BEEAB3A8A0F1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa2381b3-736a-44d6-b03d-6ae0c1eae73d", "AQAAAAEAACcQAAAAEPlbQyara4tPjOWEhLAN1DHLrq9kv0c93EjiZi1fjQNVzjlTLGA6dP2OXLIqmio3SQ==", "6d776fce-15f7-4c38-81c0-f95b18c1473f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99B7485A-20E0-4F16-8865-7112C035746C",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64afe2cb-1357-48d7-8cb5-c43fabec758e", "AQAAAAEAACcQAAAAEGO0WMbOe1Np1nuvixSz7zr93e+e2BEnfjIAi4/DoG4lk0KCTt4yWeFp2P4MmcK6AQ==", "64621015-ab38-4ce9-8554-42ab29567809" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
