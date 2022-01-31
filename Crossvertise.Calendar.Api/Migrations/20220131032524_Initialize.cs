using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crossvertise.Calendar.Api.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointment_User_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAppointment",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    AppointmentId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAppointment", x => new { x.UserId, x.AppointmentId });
                    table.ForeignKey(
                        name: "FK_UserAppointment_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAppointment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "UserName" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 1, 31, 6, 25, 24, 495, DateTimeKind.Local).AddTicks(281), "Max Mustermann" },
                    { 2L, new DateTime(2022, 1, 31, 6, 25, 24, 499, DateTimeKind.Local).AddTicks(3524), "John Smith" },
                    { 3L, new DateTime(2022, 1, 31, 6, 25, 24, 499, DateTimeKind.Local).AddTicks(3548), "Robert Turner" },
                    { 4L, new DateTime(2022, 1, 31, 6, 25, 24, 499, DateTimeKind.Local).AddTicks(3550), "Erika Gobler" }
                });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "CreatedAt", "Date", "Description", "OrganizerId" },
                values: new object[] { 1L, new DateTime(2022, 1, 31, 6, 25, 24, 501, DateTimeKind.Local).AddTicks(572), new DateTime(2022, 1, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), "Project Meeting", 1L });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "CreatedAt", "Date", "Description", "OrganizerId" },
                values: new object[] { 2L, new DateTime(2022, 1, 31, 6, 25, 24, 501, DateTimeKind.Local).AddTicks(1684), new DateTime(2022, 1, 31, 12, 0, 0, 0, DateTimeKind.Unspecified), "Lunch with John", 1L });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "CreatedAt", "Date", "Description", "OrganizerId" },
                values: new object[] { 3L, new DateTime(2022, 1, 31, 6, 25, 24, 501, DateTimeKind.Local).AddTicks(1693), new DateTime(2022, 2, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), "Team Meeting", 2L });

            migrationBuilder.InsertData(
                table: "UserAppointment",
                columns: new[] { "AppointmentId", "UserId", "CreatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2022, 1, 31, 6, 25, 24, 504, DateTimeKind.Local).AddTicks(2951) },
                    { 1L, 2L, new DateTime(2022, 1, 31, 6, 25, 24, 504, DateTimeKind.Local).AddTicks(3522) },
                    { 1L, 3L, new DateTime(2022, 1, 31, 6, 25, 24, 504, DateTimeKind.Local).AddTicks(3526) },
                    { 1L, 4L, new DateTime(2022, 1, 31, 6, 25, 24, 504, DateTimeKind.Local).AddTicks(3527) },
                    { 2L, 1L, new DateTime(2022, 1, 31, 6, 25, 24, 504, DateTimeKind.Local).AddTicks(3529) },
                    { 2L, 2L, new DateTime(2022, 1, 31, 6, 25, 24, 504, DateTimeKind.Local).AddTicks(3530) },
                    { 3L, 1L, new DateTime(2022, 1, 31, 6, 25, 24, 504, DateTimeKind.Local).AddTicks(3531) },
                    { 3L, 2L, new DateTime(2022, 1, 31, 6, 25, 24, 504, DateTimeKind.Local).AddTicks(3532) },
                    { 3L, 3L, new DateTime(2022, 1, 31, 6, 25, 24, 504, DateTimeKind.Local).AddTicks(3534) },
                    { 3L, 4L, new DateTime(2022, 1, 31, 6, 25, 24, 504, DateTimeKind.Local).AddTicks(3535) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_OrganizerId",
                table: "Appointment",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAppointment_AppointmentId",
                table: "UserAppointment",
                column: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAppointment");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
