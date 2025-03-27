using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yovoyenruta_backend.Migrations
{
    /// <inheritdoc />
    public partial class OperatorVehicleUsertypeModelsUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "operators");

            migrationBuilder.RenameColumn(
                name: "user_type",
                table: "user_types",
                newName: "type");

            migrationBuilder.AddColumn<string>(
                name: "brand",
                table: "vehicles",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "brand",
                table: "vehicles");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "user_types",
                newName: "user_type");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "operators",
                type: "bit",
                nullable: true);
        }
    }
}
