using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GraduatedSchool = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    GraduatedField = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfEntry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Asset = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("34c0160d-6db5-40c5-8597-e81318d38b8b"), new DateTime(2024, 8, 18, 12, 56, 33, 492, DateTimeKind.Utc).AddTicks(332), null, "İnsan Kaynakları Departmanı" },
                    { new Guid("78ede17c-6d8a-4f89-b0ef-eee8729c4d20"), new DateTime(2024, 8, 18, 12, 56, 33, 492, DateTimeKind.Utc).AddTicks(334), null, "Bilgi İşlem Departmanı" },
                    { new Guid("f5fd7e8f-0a7e-41d1-81ae-945b5b675f5d"), new DateTime(2024, 8, 18, 12, 56, 33, 492, DateTimeKind.Utc).AddTicks(168), null, "Yönetim Departmanı" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "CreatedDate", "DepartmentId", "LastModifiedDate", "Title" },
                values: new object[,]
                {
                    { new Guid("990765cd-4d42-4a50-9371-88ed24959cb4"), new DateTime(2024, 8, 18, 12, 56, 33, 496, DateTimeKind.Utc).AddTicks(2267), new Guid("78ede17c-6d8a-4f89-b0ef-eee8729c4d20"), null, "Yazılım Geliştirici" },
                    { new Guid("9fa7ab59-3aeb-4636-a4d8-21161c7f963a"), new DateTime(2024, 8, 18, 12, 56, 33, 496, DateTimeKind.Utc).AddTicks(2281), new Guid("78ede17c-6d8a-4f89-b0ef-eee8729c4d20"), null, "Sistem Analisti" },
                    { new Guid("d6d90efc-e099-42e7-8360-2d90e9a26f23"), new DateTime(2024, 8, 18, 12, 56, 33, 496, DateTimeKind.Utc).AddTicks(2265), new Guid("34c0160d-6db5-40c5-8597-e81318d38b8b"), null, "İK Uzmanı" },
                    { new Guid("fa7fc807-9f59-4452-ba36-0900b5186869"), new DateTime(2024, 8, 18, 12, 56, 33, 496, DateTimeKind.Utc).AddTicks(2259), new Guid("f5fd7e8f-0a7e-41d1-81ae-945b5b675f5d"), null, "Yönetici" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Asset", "BirthDate", "CreatedDate", "DateOfEntry", "DepartmentId", "Email", "FirstName", "Gender", "GraduatedField", "GraduatedSchool", "LastModifiedDate", "LastName", "Phone", "PositionId", "Status" },
                values: new object[] { new Guid("57314315-7127-431d-a144-29379e6f5c3b"), "büyükçekmece", true, new DateTime(2024, 8, 18, 12, 56, 33, 494, DateTimeKind.Utc).AddTicks(9001), new DateTime(2024, 8, 18, 12, 56, 33, 494, DateTimeKind.Utc).AddTicks(9394), new DateTime(2024, 8, 18, 12, 56, 33, 494, DateTimeKind.Utc).AddTicks(9101), new Guid("78ede17c-6d8a-4f89-b0ef-eee8729c4d20"), "hurdenizyener@gmail.com", "Hürdeniz", "Erkek", "Bilgisayar Program", "Hitit Üniversitesi", null, "Yener", "0111-111-11-11", new Guid("990765cd-4d42-4a50-9371-88ed24959cb4"), true });

            migrationBuilder.CreateIndex(
                name: "UK_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DepartmentId",
                table: "Positions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "UK_Positions_Title",
                table: "Positions",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
