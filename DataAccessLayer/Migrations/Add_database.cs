using Microsoft.EntityFrameworkCore.Migrations;

public partial class Add_database : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Prescriptions",
            columns: table => new
            {
                PrescriptionId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PatientId = table.Column<int>(type: "int", nullable: false),
                MedicalRecordId = table.Column<int>(type: "int", nullable: false),
                Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                Notes = table.Column<string>(type: "nvarchar(450)", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Prescriptions", x => x.PrescriptionId);
                table.ForeignKey(
                    name: "FK_Prescriptions_MedicalRecords_MedicalRecordId",
                    column: x => x.MedicalRecordId,
                    principalTable: "MedicalRecords",
                    principalColumn: "MedicalRecordId",
                    onDelete: ReferentialAction.Cascade); // or ReferentialAction.NoAction
                table.ForeignKey(
                    name: "FK_Prescriptions_Patients_PatientId",
                    column: x => x.PatientId,
                    principalTable: "Patients",
                    principalColumn: "PatientId",
                    onDelete: ReferentialAction.NoAction); // or ReferentialAction.SetNull
            });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Prescriptions");
    }
}