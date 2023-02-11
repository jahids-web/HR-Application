using Microsoft.EntityFrameworkCore.Migrations;

namespace DLL.Migrations
{
    public partial class ApiMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    TotalYearlyAllocatedleave = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    Leave = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    IsEmployed = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    JoiningDate = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    DeparturedDate = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    WorkHour = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalarys",
                columns: table => new
                {
                    EmployeeSalaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Month = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    PostedAt = table.Column<string>(type: "nvarchar(12)", nullable: true),
                    PostedBy = table.Column<string>(type: "nvarchar(12)", nullable: true),
                    IsProvided = table.Column<string>(type: "nvarchar(12)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalarys", x => x.EmployeeSalaryId);
                    table.ForeignKey(
                        name: "FK_EmployeeSalarys_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSalarys_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeWisePresentAbsents",
                columns: table => new
                {
                    EmployeeWisePresentAbsentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    IsPresent = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    DepartureTime = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWisePresentAbsents", x => x.EmployeeWisePresentAbsentId);
                    table.ForeignKey(
                        name: "FK_EmployeeWisePresentAbsents_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveApplications",
                columns: table => new
                {
                    LeaveApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(12)", nullable: true),
                    From = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    ApprovalDate = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    ApplicationDate = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    LastUpdatedAt = table.Column<string>(type: "nvarchar(12)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApplications", x => x.LeaveApplicationId);
                    table.ForeignKey(
                        name: "FK_LeaveApplications_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveApplications_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalarys_DepartmentId",
                table: "EmployeeSalarys",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalarys_EmployeeId",
                table: "EmployeeSalarys",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWisePresentAbsents_EmployeeId",
                table: "EmployeeWisePresentAbsents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_DepartmentId",
                table: "LeaveApplications",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_EmployeeId",
                table: "LeaveApplications",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSalarys");

            migrationBuilder.DropTable(
                name: "EmployeeWisePresentAbsents");

            migrationBuilder.DropTable(
                name: "LeaveApplications");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
