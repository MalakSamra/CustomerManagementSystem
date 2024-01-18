using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class modification_Cst_Id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_user_customer_CustomerId",
                table: "customer_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer_user",
                table: "customer_user");

            migrationBuilder.DropColumn(
                name: "Cst_id",
                table: "customer_user");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "customer_user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer_user",
                table: "customer_user",
                columns: new[] { "UserID", "CustomerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_customer_user_customer_CustomerId",
                table: "customer_user",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_user_customer_CustomerId",
                table: "customer_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer_user",
                table: "customer_user");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "customer_user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Cst_id",
                table: "customer_user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer_user",
                table: "customer_user",
                columns: new[] { "UserID", "Cst_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_customer_user_customer_CustomerId",
                table: "customer_user",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "Id");
        }
    }
}
