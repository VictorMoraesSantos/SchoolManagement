using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Academic.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class nameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departaments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_DomainEvent_Departaments_DepartmentId",
                table: "DomainEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departaments",
                table: "Departaments");

            migrationBuilder.RenameTable(
                name: "Departaments",
                newName: "Departments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DomainEvent_Departments_DepartmentId",
                table: "DomainEvent",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_DomainEvent_Departments_DepartmentId",
                table: "DomainEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Departaments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departaments",
                table: "Departaments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departaments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DomainEvent_Departaments_DepartmentId",
                table: "DomainEvent",
                column: "DepartmentId",
                principalTable: "Departaments",
                principalColumn: "Id");
        }
    }
}
