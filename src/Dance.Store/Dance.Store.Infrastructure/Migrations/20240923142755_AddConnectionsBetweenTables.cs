using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dance.Store.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConnectionsBetweenTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_ClassId",
                table: "StudentRegistrations",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_StatusId",
                table: "StudentRegistrations",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_StudentId",
                table: "StudentRegistrations",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrations_DanceClasses_ClassId",
                table: "StudentRegistrations",
                column: "ClassId",
                principalTable: "DanceClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrations_RegistrationStatuses_StatusId",
                table: "StudentRegistrations",
                column: "StatusId",
                principalTable: "RegistrationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrations_Students_StudentId",
                table: "StudentRegistrations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrations_DanceClasses_ClassId",
                table: "StudentRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrations_RegistrationStatuses_StatusId",
                table: "StudentRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrations_Students_StudentId",
                table: "StudentRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegistrations_ClassId",
                table: "StudentRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegistrations_StatusId",
                table: "StudentRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegistrations_StudentId",
                table: "StudentRegistrations");
        }
    }
}
