using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaluteStocksAPI.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnualEarning_Earnings_EarningsSymbol",
                table: "AnnualEarning");

            migrationBuilder.DropForeignKey(
                name: "FK_CashFlowReport_CashFlows_CashFlowSymbol",
                table: "CashFlowReport");

            migrationBuilder.DropForeignKey(
                name: "FK_CashFlowReport_CashFlows_Symbol",
                table: "CashFlowReport");

            migrationBuilder.DropForeignKey(
                name: "FK_QuarterlyEarning_Earnings_EarningsSymbol",
                table: "QuarterlyEarning");

            migrationBuilder.DropIndex(
                name: "IX_QuarterlyEarning_EarningsSymbol",
                table: "QuarterlyEarning");

            migrationBuilder.DropIndex(
                name: "IX_AnnualEarning_EarningsSymbol",
                table: "AnnualEarning");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashFlowReport",
                table: "CashFlowReport");

            migrationBuilder.DropIndex(
                name: "IX_CashFlowReport_CashFlowSymbol",
                table: "CashFlowReport");

            migrationBuilder.DropColumn(
                name: "EarningsSymbol",
                table: "QuarterlyEarning");

            migrationBuilder.DropColumn(
                name: "EarningsSymbol",
                table: "AnnualEarning");

            migrationBuilder.DropColumn(
                name: "CashFlowSymbol",
                table: "CashFlowReport");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CashFlowReport");

            migrationBuilder.RenameTable(
                name: "CashFlowReport",
                newName: "CashFlowAnnualReport");

            migrationBuilder.RenameIndex(
                name: "IX_CashFlowReport_Symbol",
                table: "CashFlowAnnualReport",
                newName: "IX_CashFlowAnnualReport_Symbol");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "QuarterlyEarning",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "AnnualEarning",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashFlowAnnualReport",
                table: "CashFlowAnnualReport",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CashFlowQuarterlyReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FiscalDateEnding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingCashFlow = table.Column<long>(type: "bigint", nullable: true),
                    PaymentsForOperatingActivities = table.Column<long>(type: "bigint", nullable: true),
                    ProceedsFromOperatingActivities = table.Column<long>(type: "bigint", nullable: true),
                    ChangeInOperatingLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    ChangeInOperatingAssets = table.Column<long>(type: "bigint", nullable: true),
                    DepreciationDepletionAndAmortization = table.Column<long>(type: "bigint", nullable: true),
                    CapitalExpenditures = table.Column<long>(type: "bigint", nullable: true),
                    ChangeInReceivables = table.Column<long>(type: "bigint", nullable: true),
                    ChangeInInventory = table.Column<long>(type: "bigint", nullable: true),
                    ProfitLoss = table.Column<long>(type: "bigint", nullable: true),
                    CashflowFromInvestment = table.Column<long>(type: "bigint", nullable: true),
                    CashflowFromFinancing = table.Column<long>(type: "bigint", nullable: true),
                    ProceedsFromRepaymentsOfShortTermDebt = table.Column<long>(type: "bigint", nullable: true),
                    PaymentsForRepurchaseOfCommonStock = table.Column<long>(type: "bigint", nullable: true),
                    PaymentsForRepurchaseOfEquity = table.Column<long>(type: "bigint", nullable: true),
                    PaymentsForRepurchaseOfPreferredStock = table.Column<long>(type: "bigint", nullable: true),
                    DividendPayout = table.Column<long>(type: "bigint", nullable: true),
                    DividendPayoutCommonStock = table.Column<long>(type: "bigint", nullable: true),
                    DividendPayoutPreferredStock = table.Column<long>(type: "bigint", nullable: true),
                    ProceedsFromIssuanceOfCommonStock = table.Column<long>(type: "bigint", nullable: true),
                    ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet = table.Column<long>(type: "bigint", nullable: true),
                    ProceedsFromIssuanceOfPreferredStock = table.Column<long>(type: "bigint", nullable: true),
                    ProceedsFromRepurchaseOfEquity = table.Column<long>(type: "bigint", nullable: true),
                    ProceedsFromSaleOfTreasuryStock = table.Column<long>(type: "bigint", nullable: true),
                    ChangeInCashAndCashEquivalents = table.Column<long>(type: "bigint", nullable: true),
                    ChangeInExchangeRate = table.Column<long>(type: "bigint", nullable: true),
                    NetIncome = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlowQuarterlyReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashFlowQuarterlyReport_CashFlows_Symbol",
                        column: x => x.Symbol,
                        principalTable: "CashFlows",
                        principalColumn: "Symbol");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuarterlyEarning_Symbol",
                table: "QuarterlyEarning",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualEarning_Symbol",
                table: "AnnualEarning",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowQuarterlyReport_Symbol",
                table: "CashFlowQuarterlyReport",
                column: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnualEarning_Earnings_Symbol",
                table: "AnnualEarning",
                column: "Symbol",
                principalTable: "Earnings",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlowAnnualReport_CashFlows_Symbol",
                table: "CashFlowAnnualReport",
                column: "Symbol",
                principalTable: "CashFlows",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_QuarterlyEarning_Earnings_Symbol",
                table: "QuarterlyEarning",
                column: "Symbol",
                principalTable: "Earnings",
                principalColumn: "Symbol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnualEarning_Earnings_Symbol",
                table: "AnnualEarning");

            migrationBuilder.DropForeignKey(
                name: "FK_CashFlowAnnualReport_CashFlows_Symbol",
                table: "CashFlowAnnualReport");

            migrationBuilder.DropForeignKey(
                name: "FK_QuarterlyEarning_Earnings_Symbol",
                table: "QuarterlyEarning");

            migrationBuilder.DropTable(
                name: "CashFlowQuarterlyReport");

            migrationBuilder.DropIndex(
                name: "IX_QuarterlyEarning_Symbol",
                table: "QuarterlyEarning");

            migrationBuilder.DropIndex(
                name: "IX_AnnualEarning_Symbol",
                table: "AnnualEarning");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashFlowAnnualReport",
                table: "CashFlowAnnualReport");

            migrationBuilder.RenameTable(
                name: "CashFlowAnnualReport",
                newName: "CashFlowReport");

            migrationBuilder.RenameIndex(
                name: "IX_CashFlowAnnualReport_Symbol",
                table: "CashFlowReport",
                newName: "IX_CashFlowReport_Symbol");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "QuarterlyEarning",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarningsSymbol",
                table: "QuarterlyEarning",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "AnnualEarning",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EarningsSymbol",
                table: "AnnualEarning",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CashFlowSymbol",
                table: "CashFlowReport",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CashFlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashFlowReport",
                table: "CashFlowReport",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterlyEarning_EarningsSymbol",
                table: "QuarterlyEarning",
                column: "EarningsSymbol");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualEarning_EarningsSymbol",
                table: "AnnualEarning",
                column: "EarningsSymbol");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowReport_CashFlowSymbol",
                table: "CashFlowReport",
                column: "CashFlowSymbol");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnualEarning_Earnings_EarningsSymbol",
                table: "AnnualEarning",
                column: "EarningsSymbol",
                principalTable: "Earnings",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlowReport_CashFlows_CashFlowSymbol",
                table: "CashFlowReport",
                column: "CashFlowSymbol",
                principalTable: "CashFlows",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlowReport_CashFlows_Symbol",
                table: "CashFlowReport",
                column: "Symbol",
                principalTable: "CashFlows",
                principalColumn: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_QuarterlyEarning_Earnings_EarningsSymbol",
                table: "QuarterlyEarning",
                column: "EarningsSymbol",
                principalTable: "Earnings",
                principalColumn: "Symbol");
        }
    }
}
