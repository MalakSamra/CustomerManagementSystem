using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class adding_data_to_cu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Modification_UserID",
                table: "customer_user",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_user_Modification_UserID",
                table: "customer_user",
                column: "Modification_UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_user_AspNetUsers_Modification_UserID",
                table: "customer_user",
                column: "Modification_UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_user_AspNetUsers_Modification_UserID",
                table: "customer_user");

            migrationBuilder.DropIndex(
                name: "IX_customer_user_Modification_UserID",
                table: "customer_user");

            migrationBuilder.DropColumn(
                name: "Modification_UserID",
                table: "customer_user");
        }
    }
}
