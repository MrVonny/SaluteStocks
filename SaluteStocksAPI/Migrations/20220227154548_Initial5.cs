using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaluteStocksAPI.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOverviews_BalanceSheets_Symbol",
                table: "CompanyOverviews");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOverviews_CashFlows_Symbol",
                table: "CompanyOverviews");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOverviews_Earnings_Symbol",
                table: "CompanyOverviews");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOverviews_IncomeStatements_Symbol",
                table: "CompanyOverviews");

            migrationBuilder.AddForeignKey(
                name: "FK_BalanceSheets_CompanyOverviews_Symbol",
                table: "BalanceSheets",
                column: "Symbol",
                principalTable: "CompanyOverviews",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlows_CompanyOverviews_Symbol",
                table: "CashFlows",
                column: "Symbol",
                principalTable: "CompanyOverviews",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Earnings_CompanyOverviews_Symbol",
                table: "Earnings",
                column: "Symbol",
                principalTable: "CompanyOverviews",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeStatements_CompanyOverviews_Symbol",
                table: "IncomeStatements",
                column: "Symbol",
                principalTable: "CompanyOverviews",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BalanceSheets_CompanyOverviews_Symbol",
                table: "BalanceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_CashFlows_CompanyOverviews_Symbol",
                table: "CashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_Earnings_CompanyOverviews_Symbol",
                table: "Earnings");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeStatements_CompanyOverviews_Symbol",
                table: "IncomeStatements");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOverviews_BalanceSheets_Symbol",
                table: "CompanyOverviews",
                column: "Symbol",
                principalTable: "BalanceSheets",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOverviews_CashFlows_Symbol",
                table: "CompanyOverviews",
                column: "Symbol",
                principalTable: "CashFlows",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOverviews_Earnings_Symbol",
                table: "CompanyOverviews",
                column: "Symbol",
                principalTable: "Earnings",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOverviews_IncomeStatements_Symbol",
                table: "CompanyOverviews",
                column: "Symbol",
                principalTable: "IncomeStatements",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
