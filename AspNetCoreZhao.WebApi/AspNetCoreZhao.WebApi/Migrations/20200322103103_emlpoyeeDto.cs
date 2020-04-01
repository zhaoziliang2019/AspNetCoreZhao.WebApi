using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreZhao.WebApi.Migrations
{
    public partial class emlpoyeeDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("77f97e55-be65-470a-a814-379df619da3e"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("11fc1cdf-47de-43e6-8cce-098da8017ecc"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("c3b1ce1e-3dad-4547-aebe-0ffa42e1a303"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("6f6cbfb0-11c2-45c8-ab77-49b04070a919"), "TuBaolan Company", "Alibaba" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "LastName", "gender" },
                values: new object[] { new Guid("e3d1f618-1599-4b13-b25b-793a4aa8b54a"), new Guid("0f47e01a-c072-427d-a5a6-27a8ae96380e"), new DateTime(1976, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "0321", "123", "456", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "LastName", "gender" },
                values: new object[] { new Guid("a1bb1375-b7de-4a5f-8954-71a61595b9fd"), new Guid("35ca78f2-d595-4890-93c4-db6d5d258f5c"), new DateTime(1976, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "0321", "098", "124", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6f6cbfb0-11c2-45c8-ab77-49b04070a919"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("a1bb1375-b7de-4a5f-8954-71a61595b9fd"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("e3d1f618-1599-4b13-b25b-793a4aa8b54a"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("77f97e55-be65-470a-a814-379df619da3e"), "TuBaolan Company", "Alibaba" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "LastName", "gender" },
                values: new object[] { new Guid("11fc1cdf-47de-43e6-8cce-098da8017ecc"), new Guid("0f47e01a-c072-427d-a5a6-27a8ae96380e"), new DateTime(1976, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "0321", "123", "456", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "LastName", "gender" },
                values: new object[] { new Guid("c3b1ce1e-3dad-4547-aebe-0ffa42e1a303"), new Guid("35ca78f2-d595-4890-93c4-db6d5d258f5c"), new DateTime(1976, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "0321", "098", "124", 1 });
        }
    }
}
