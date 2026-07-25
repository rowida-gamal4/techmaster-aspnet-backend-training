using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingCenter.Api.Migrations
{
    /// <inheritdoc />
    public partial class updateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "IsActive",
                value: false);

            migrationBuilder.InsertData(
                table: "TrainingTracks",
                columns: new[] { "TrackId", "Capacity", "Code", "CreatedAt", "Description", "EndDate", "InstructorId", "IsDeleted", "Level", "Price", "StartDate", "Status", "Title" },
                values: new object[] { 4, 1, "T-101", new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Testing Track", new DateTime(2026, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 2, 2000m, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "Testing" });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "CreatedAt", "EnrollmentDate", "FinalResult", "ProgressPercentage", "Status", "StudentId", "TrainingTrackId", "UpdatedAt" },
                values: new object[] { 6, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 100, 2, 4, 4, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TrainingTracks",
                keyColumn: "TrackId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "IsActive",
                value: true);
        }
    }
}
