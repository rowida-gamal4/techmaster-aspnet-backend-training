using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingCenter.Api.Migrations
{
    /// <inheritdoc />
    public partial class updateSeedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 6,
                column: "Status",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 6,
                column: "Status",
                value: 2);
        }
    }
}
