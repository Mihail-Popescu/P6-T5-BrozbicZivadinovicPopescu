using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectOBS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Deposit_DepositId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Transfer_TransferId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Withdrawal_WithdrawalId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "WithdrawalId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TransferId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepositId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Deposit_DepositId",
                table: "Transactions",
                column: "DepositId",
                principalTable: "Deposit",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Transfer_TransferId",
                table: "Transactions",
                column: "TransferId",
                principalTable: "Transfer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Withdrawal_WithdrawalId",
                table: "Transactions",
                column: "WithdrawalId",
                principalTable: "Withdrawal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Deposit_DepositId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Transfer_TransferId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Withdrawal_WithdrawalId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "WithdrawalId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransferId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepositId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Deposit_DepositId",
                table: "Transactions",
                column: "DepositId",
                principalTable: "Deposit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Transfer_TransferId",
                table: "Transactions",
                column: "TransferId",
                principalTable: "Transfer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Withdrawal_WithdrawalId",
                table: "Transactions",
                column: "WithdrawalId",
                principalTable: "Withdrawal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
