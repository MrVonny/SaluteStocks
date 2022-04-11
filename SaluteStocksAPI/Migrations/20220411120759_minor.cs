using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaluteStocksAPI.Migrations
{
    public partial class minor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BalanceSheetAnnualReport_BalanceSheets_Symbol",
                table: "BalanceSheetAnnualReport");

            migrationBuilder.DropForeignKey(
                name: "FK_BalanceSheetQuarterlyReports_BalanceSheets_Symbol",
                table: "BalanceSheetQuarterlyReports");

            migrationBuilder.DropForeignKey(
                name: "FK_BalanceSheets_CompanyOverviews_Symbol",
                table: "BalanceSheets");

            migrationBuilder.DropForeignKey(
                name: "FK_CashFlowAnnualReport_CashFlows_Symbol",
                table: "CashFlowAnnualReport");

            migrationBuilder.DropForeignKey(
                name: "FK_CashFlowQuarterlyReport_CashFlows_Symbol",
                table: "CashFlowQuarterlyReport");

            migrationBuilder.DropForeignKey(
                name: "FK_CashFlows_CompanyOverviews_Symbol",
                table: "CashFlows");

            migrationBuilder.DropForeignKey(
                name: "FK_Earnings_CompanyOverviews_Symbol",
                table: "Earnings");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeStatementAnnualReport_IncomeStatements_Symbol",
                table: "IncomeStatementAnnualReport");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeStatementQuarterlyReport_IncomeStatements_Symbol",
                table: "IncomeStatementQuarterlyReport");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeStatements_CompanyOverviews_Symbol",
                table: "IncomeStatements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncomeStatements",
                table: "IncomeStatements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyOverviews",
                table: "CompanyOverviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashFlows",
                table: "CashFlows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BalanceSheets",
                table: "BalanceSheets");

            migrationBuilder.RenameTable(
                name: "IncomeStatements",
                newName: "IncomeStatement");

            migrationBuilder.RenameTable(
                name: "CompanyOverviews",
                newName: "CompanyOverview");

            migrationBuilder.RenameTable(
                name: "CashFlows",
                newName: "CashFlow");

            migrationBuilder.RenameTable(
                name: "BalanceSheets",
                newName: "BalanceSheet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncomeStatement",
                table: "IncomeStatement",
                column: "Symbol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyOverview",
                table: "CompanyOverview",
                column: "Symbol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashFlow",
                table: "CashFlow",
                column: "Symbol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BalanceSheet",
                table: "BalanceSheet",
                column: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_BalanceSheet_CompanyOverview_Symbol",
                table: "BalanceSheet",
                column: "Symbol",
                principalTable: "CompanyOverview",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BalanceSheetAnnualReport_BalanceSheet_Symbol",
                table: "BalanceSheetAnnualReport",
                column: "Symbol",
                principalTable: "BalanceSheet",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_BalanceSheetQuarterlyReports_BalanceSheet_Symbol",
                table: "BalanceSheetQuarterlyReports",
                column: "Symbol",
                principalTable: "BalanceSheet",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlow_CompanyOverview_Symbol",
                table: "CashFlow",
                column: "Symbol",
                principalTable: "CompanyOverview",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlowAnnualReport_CashFlow_Symbol",
                table: "CashFlowAnnualReport",
                column: "Symbol",
                principalTable: "CashFlow",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlowQuarterlyReport_CashFlow_Symbol",
                table: "CashFlowQuarterlyReport",
                column: "Symbol",
                principalTable: "CashFlow",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_Earnings_CompanyOverview_Symbol",
                table: "Earnings",
                column: "Symbol",
                principalTable: "CompanyOverview",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeStatement_CompanyOverview_Symbol",
                table: "IncomeStatement",
                column: "Symbol",
                principalTable: "CompanyOverview",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeStatementAnnualReport_IncomeStatement_Symbol",
                table: "IncomeStatementAnnualReport",
                column: "Symbol",
                principalTable: "IncomeStatement",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeStatementQuarterlyReport_IncomeStatement_Symbol",
                table: "IncomeStatementQuarterlyReport",
                column: "Symbol",
                principalTable: "IncomeStatement",
                principalColumn: "Symbol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BalanceSheet_CompanyOverview_Symbol",
                table: "BalanceSheet");

            migrationBuilder.DropForeignKey(
                name: "FK_BalanceSheetAnnualReport_BalanceSheet_Symbol",
                table: "BalanceSheetAnnualReport");

            migrationBuilder.DropForeignKey(
                name: "FK_BalanceSheetQuarterlyReports_BalanceSheet_Symbol",
                table: "BalanceSheetQuarterlyReports");

            migrationBuilder.DropForeignKey(
                name: "FK_CashFlow_CompanyOverview_Symbol",
                table: "CashFlow");

            migrationBuilder.DropForeignKey(
                name: "FK_CashFlowAnnualReport_CashFlow_Symbol",
                table: "CashFlowAnnualReport");

            migrationBuilder.DropForeignKey(
                name: "FK_CashFlowQuarterlyReport_CashFlow_Symbol",
                table: "CashFlowQuarterlyReport");

            migrationBuilder.DropForeignKey(
                name: "FK_Earnings_CompanyOverview_Symbol",
                table: "Earnings");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeStatement_CompanyOverview_Symbol",
                table: "IncomeStatement");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeStatementAnnualReport_IncomeStatement_Symbol",
                table: "IncomeStatementAnnualReport");

            migrationBuilder.DropForeignKey(
                name: "FK_IncomeStatementQuarterlyReport_IncomeStatement_Symbol",
                table: "IncomeStatementQuarterlyReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncomeStatement",
                table: "IncomeStatement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyOverview",
                table: "CompanyOverview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashFlow",
                table: "CashFlow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BalanceSheet",
                table: "BalanceSheet");

            migrationBuilder.RenameTable(
                name: "IncomeStatement",
                newName: "IncomeStatements");

            migrationBuilder.RenameTable(
                name: "CompanyOverview",
                newName: "CompanyOverviews");

            migrationBuilder.RenameTable(
                name: "CashFlow",
                newName: "CashFlows");

            migrationBuilder.RenameTable(
                name: "BalanceSheet",
                newName: "BalanceSheets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncomeStatements",
                table: "IncomeStatements",
                column: "Symbol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyOverviews",
                table: "CompanyOverviews",
                column: "Symbol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashFlows",
                table: "CashFlows",
                column: "Symbol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BalanceSheets",
                table: "BalanceSheets",
                column: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_BalanceSheetAnnualReport_BalanceSheets_Symbol",
                table: "BalanceSheetAnnualReport",
                column: "Symbol",
                principalTable: "BalanceSheets",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_BalanceSheetQuarterlyReports_BalanceSheets_Symbol",
                table: "BalanceSheetQuarterlyReports",
                column: "Symbol",
                principalTable: "BalanceSheets",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_BalanceSheets_CompanyOverviews_Symbol",
                table: "BalanceSheets",
                column: "Symbol",
                principalTable: "CompanyOverviews",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlowAnnualReport_CashFlows_Symbol",
                table: "CashFlowAnnualReport",
                column: "Symbol",
                principalTable: "CashFlows",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlowQuarterlyReport_CashFlows_Symbol",
                table: "CashFlowQuarterlyReport",
                column: "Symbol",
                principalTable: "CashFlows",
                principalColumn: "Symbol");

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
                name: "FK_IncomeStatementAnnualReport_IncomeStatements_Symbol",
                table: "IncomeStatementAnnualReport",
                column: "Symbol",
                principalTable: "IncomeStatements",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeStatementQuarterlyReport_IncomeStatements_Symbol",
                table: "IncomeStatementQuarterlyReport",
                column: "Symbol",
                principalTable: "IncomeStatements",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeStatements_CompanyOverviews_Symbol",
                table: "IncomeStatements",
                column: "Symbol",
                principalTable: "CompanyOverviews",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
