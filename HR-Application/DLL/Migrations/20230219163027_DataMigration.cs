using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLL.Migrations
{
    public partial class DataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalarys_Employees_EmployeeId",
                table: "EmployeeSalarys");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWisePresentAbsents_Employees_EmployeeId",
                table: "EmployeeWisePresentAbsents");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_Employees_EmployeeId",
                table: "LeaveApplications");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplications_EmployeeId",
                table: "LeaveApplications");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeWisePresentAbsents_EmployeeId",
                table: "EmployeeWisePresentAbsents");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSalarys_EmployeeId",
                table: "EmployeeSalarys");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "LeaveApplications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "LeaveApplications",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeWisePresentAbsents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "EmployeeWisePresentAbsents",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "EmployeeSalarys",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "EmployeeSalarys",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkHour",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)");

            migrationBuilder.AlterColumn<int>(
                name: "TotalYearlyAllocatedleave",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Leave",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoiningDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "IsEmployed",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeparturedDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_EmployeeId1",
                table: "LeaveApplications",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWisePresentAbsents_EmployeeId1",
                table: "EmployeeWisePresentAbsents",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalarys_EmployeeId1",
                table: "EmployeeSalarys",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalarys_Employees_EmployeeId1",
                table: "EmployeeSalarys",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWisePresentAbsents_Employees_EmployeeId1",
                table: "EmployeeWisePresentAbsents",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_Employees_EmployeeId1",
                table: "LeaveApplications",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalarys_Employees_EmployeeId1",
                table: "EmployeeSalarys");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWisePresentAbsents_Employees_EmployeeId1",
                table: "EmployeeWisePresentAbsents");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_Employees_EmployeeId1",
                table: "LeaveApplications");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplications_EmployeeId1",
                table: "LeaveApplications");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeWisePresentAbsents_EmployeeId1",
                table: "EmployeeWisePresentAbsents");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSalarys_EmployeeId1",
                table: "EmployeeSalarys");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "EmployeeWisePresentAbsents");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "EmployeeSalarys");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "LeaveApplications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeWisePresentAbsents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeSalarys",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WorkHour",
                table: "Employees",
                type: "nvarchar(5)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TotalYearlyAllocatedleave",
                table: "Employees",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Employees",
                type: "nvarchar(5)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Employees",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Leave",
                table: "Employees",
                type: "nvarchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "JoiningDate",
                table: "Employees",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "IsEmployed",
                table: "Employees",
                type: "nvarchar(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Employees",
                type: "nvarchar(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Employees",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeparturedDate",
                table: "Employees",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Employees",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_EmployeeId",
                table: "LeaveApplications",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWisePresentAbsents_EmployeeId",
                table: "EmployeeWisePresentAbsents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalarys_EmployeeId",
                table: "EmployeeSalarys",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalarys_Employees_EmployeeId",
                table: "EmployeeSalarys",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWisePresentAbsents_Employees_EmployeeId",
                table: "EmployeeWisePresentAbsents",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_Employees_EmployeeId",
                table: "LeaveApplications",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
