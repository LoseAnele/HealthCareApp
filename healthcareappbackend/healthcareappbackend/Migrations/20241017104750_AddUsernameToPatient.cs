using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthcareappbackend.Migrations
{
    public partial class AddUsernameToPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Patients");
        }
    }
}
