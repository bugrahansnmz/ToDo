using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UserID",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "ToDos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Categories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_UserID",
                table: "ToDos",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UserID",
                table: "Categories",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Users_UserID",
                table: "ToDos",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_UserID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Users_UserID",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_UserID",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "ToDos");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_UserID",
                table: "Categories",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
