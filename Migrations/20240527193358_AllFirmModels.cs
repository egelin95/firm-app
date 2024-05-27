using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace firm_app.Migrations
{
    public partial class AllFirmModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ContactPerson = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ContactPhoneNumber = table.Column<int>(type: "int", nullable: true),
                    ContactEmail = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    JobTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    SalaryLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.JobTitleId);
                });

            migrationBuilder.CreateTable(
                name: "BranchOffices",
                columns: table => new
                {
                    BranchOfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistryNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ContactPerson = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ContactPhoneNumber = table.Column<int>(type: "int", nullable: true),
                    ContactEmail = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchOffices", x => x.BranchOfficeId);
                    table.ForeignKey(
                        name: "FK_BranchOffices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchOfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ContactPerson = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ContactPhoneNumber = table.Column<int>(type: "int", nullable: true),
                    ContactEmail = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Departments_BranchOffices_BranchOfficeId",
                        column: x => x.BranchOfficeId,
                        principalTable: "BranchOffices",
                        principalColumn: "BranchOfficeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PersonalIdentificationNumber = table.Column<int>(type: "int", nullable: false),
                    ContactAddress = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ContactPhoneNumber = table.Column<int>(type: "int", nullable: true),
                    ContactEmail = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    AtWorkSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtWorkUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Employees_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "JobTitleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessLevels",
                columns: table => new
                {
                    AccessLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    AccessType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLevels", x => x.AccessLevelId);
                    table.ForeignKey(
                        name: "FK_AccessLevels_Employees_AccessLevelId",
                        column: x => x.AccessLevelId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedItems",
                columns: table => new
                {
                    BorrowedItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    BorrowedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedItems", x => x.BorrowedItemId);
                    table.ForeignKey(
                        name: "FK_BorrowedItems_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeChildren",
                columns: table => new
                {
                    EmployeeChildId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    LastName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeChildren", x => x.EmployeeChildId);
                    table.ForeignKey(
                        name: "FK_EmployeeChildren_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthChecks",
                columns: table => new
                {
                    HealthCheckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthChecks", x => x.HealthCheckId);
                    table.ForeignKey(
                        name: "FK_HealthChecks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Topic = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    State = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Recipient = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SickLeave",
                columns: table => new
                {
                    SickLeaveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SickLeave", x => x.SickLeaveId);
                    table.ForeignKey(
                        name: "FK_SickLeave_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    VacationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.VacationId);
                    table.ForeignKey(
                        name: "FK_Vacations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkTimes",
                columns: table => new
                {
                    WorkTimeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comment = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTimes", x => x.WorkTimeId);
                    table.ForeignKey(
                        name: "FK_WorkTimes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedItems_EmployeeId",
                table: "BorrowedItems",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchOffices_CompanyId",
                table: "BranchOffices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_BranchOfficeId",
                table: "Departments",
                column: "BranchOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeChildren_EmployeeId",
                table: "EmployeeChildren",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobTitleId",
                table: "Employees",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthChecks_EmployeeId",
                table: "HealthChecks",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_EmployeeId",
                table: "Requests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SickLeave_EmployeeId",
                table: "SickLeave",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_EmployeeId",
                table: "Vacations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimes_EmployeeId",
                table: "WorkTimes",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessLevels");

            migrationBuilder.DropTable(
                name: "BorrowedItems");

            migrationBuilder.DropTable(
                name: "EmployeeChildren");

            migrationBuilder.DropTable(
                name: "HealthChecks");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "SickLeave");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "WorkTimes");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "BranchOffices");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
