using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiNet.Migrations
{
    /// <inheritdoc />
    public partial class AddTblCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Merchandise",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Merchandise_CategoryId",
                table: "Merchandise",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Merchandise_Categories_CategoryId",
                table: "Merchandise",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Merchandise_Categories_CategoryId",
                table: "Merchandise");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Merchandise_CategoryId",
                table: "Merchandise");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Merchandise");
        }
    }
}
