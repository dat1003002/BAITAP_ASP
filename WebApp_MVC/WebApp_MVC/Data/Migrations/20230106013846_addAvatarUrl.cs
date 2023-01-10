using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_MVC.Data.Migrations
{
    public partial class addAvatarUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image",
                table: "Product",
                newName: "imageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "Product",
                newName: "image");
        }
    }
}
