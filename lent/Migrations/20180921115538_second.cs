using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lent.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "Item",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_UserID",
                table: "Item",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_UserID1",
                table: "Item",
                column: "UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_UserID",
                table: "Item",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_UserID1",
                table: "Item",
                column: "UserID1",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_UserID",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_UserID1",
                table: "Item");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Item_UserID",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_UserID1",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Item");
        }
    }
}
