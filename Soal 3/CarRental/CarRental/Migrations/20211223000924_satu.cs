using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRental.Migrations
{
    public partial class satu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_M_Car",
                columns: table => new
                {
                    CarId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Car", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Tb_T_Employee_Tb_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Tb_M_Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_Rent",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerId1 = table.Column<int>(type: "int", nullable: true),
                    EmployeeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_Rent", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Tb_T_Rent_Tb_M_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Tb_M_Car",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_T_Rent_Tb_T_Customer_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Tb_T_Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_T_Rent_Tb_T_Employee_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Tb_T_Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_T_History",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_T_History", x => x.HistoryId);
                    table.ForeignKey(
                        name: "FK_Tb_T_History_Tb_T_Rent_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Tb_T_Rent",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_Employee_Email",
                table: "Tb_T_Employee",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_Employee_PhoneNumber",
                table: "Tb_T_Employee",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_Employee_RoleId",
                table: "Tb_T_Employee",
                column: "RoleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_History_OrderId",
                table: "Tb_T_History",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_Rent_CarId",
                table: "Tb_T_Rent",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_Rent_CustomerId1",
                table: "Tb_T_Rent",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_T_Rent_EmployeeId1",
                table: "Tb_T_Rent",
                column: "EmployeeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_T_History");

            migrationBuilder.DropTable(
                name: "Tb_T_Rent");

            migrationBuilder.DropTable(
                name: "Tb_M_Car");

            migrationBuilder.DropTable(
                name: "Tb_T_Customer");

            migrationBuilder.DropTable(
                name: "Tb_T_Employee");

            migrationBuilder.DropTable(
                name: "Tb_M_Role");
        }
    }
}
