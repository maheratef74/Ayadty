using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableClinic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Clinic_ClinicId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_ClinicId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "ClinicId",
                table: "Prescriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClinicId",
                table: "Prescriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_ClinicId",
                table: "Prescriptions",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Clinic_ClinicId",
                table: "Prescriptions",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "ClinicId");
        }
    }
}
