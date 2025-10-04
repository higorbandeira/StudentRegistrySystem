using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "school");

            migrationBuilder.CreateTable(
                name: "guardians",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guardians", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "school",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    intended_school_year = table.Column<int>(type: "integer", nullable: false),
                    registration_status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DirectorApproval",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    ResponsiblePerson = table.Column<string>(type: "text", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorApproval", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectorApproval_Students_student_id",
                        column: x => x.student_id,
                        principalSchema: "school",
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    SentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Channel = table.Column<int>(type: "integer", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    student_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "school",
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_Students_student_id",
                        column: x => x.student_id,
                        principalSchema: "school",
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notification_guardians_RecipientId",
                        column: x => x.RecipientId,
                        principalSchema: "school",
                        principalTable: "guardians",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student_guardians",
                schema: "school",
                columns: table => new
                {
                    student_id = table.Column<Guid>(type: "uuid", nullable: false),
                    guardian_id = table.Column<Guid>(type: "uuid", nullable: false),
                    relationship = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    is_primary_contact = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student_guardians", x => new { x.student_id, x.guardian_id });
                    table.ForeignKey(
                        name: "FK_student_guardians_Students_student_id",
                        column: x => x.student_id,
                        principalSchema: "school",
                        principalTable: "Students",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_guardians_guardians_guardian_id",
                        column: x => x.guardian_id,
                        principalSchema: "school",
                        principalTable: "guardians",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectorApproval_student_id",
                table: "DirectorApproval",
                column: "student_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_RecipientId",
                table: "Notification",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_student_id",
                table: "Notification",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_StudentId",
                table: "Notification",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_student_guardians_guardian_id",
                schema: "school",
                table: "student_guardians",
                column: "guardian_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectorApproval");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "student_guardians",
                schema: "school");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "school");

            migrationBuilder.DropTable(
                name: "guardians",
                schema: "school");
        }
    }
}
