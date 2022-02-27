using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaluteStocksAPI.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashFlowReport_CashFlows_CashFlowSymbol1",
                table: "CashFlowReport");

            migrationBuilder.DropTable(
                name: "BalanceSheetReport");

            migrationBuilder.DropTable(
                name: "IncomeStatementReport");

            migrationBuilder.DropIndex(
                name: "IX_CashFlowReport_CashFlowSymbol1",
                table: "CashFlowReport");

            migrationBuilder.DropColumn(
                name: "CashFlowSymbol1",
                table: "CashFlowReport");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "CashFlowReport",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CashFlowReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BalanceSheetAnnualReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FiscalDateEnding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAssets = table.Column<long>(type: "bigint", nullable: true),
                    TotalCurrentAssets = table.Column<long>(type: "bigint", nullable: true),
                    CashAndCashEquivalentsAtCarryingValue = table.Column<long>(type: "bigint", nullable: true),
                    CashAndShortTermInvestments = table.Column<long>(type: "bigint", nullable: true),
                    Inventory = table.Column<long>(type: "bigint", nullable: true),
                    CurrentNetReceivables = table.Column<long>(type: "bigint", nullable: true),
                    TotalNonCurrentAssets = table.Column<long>(type: "bigint", nullable: true),
                    PropertyPlantEquipment = table.Column<long>(type: "bigint", nullable: true),
                    AccumulatedDepreciationAmortizationPPE = table.Column<long>(type: "bigint", nullable: true),
                    IntangibleAssets = table.Column<long>(type: "bigint", nullable: true),
                    IntangibleAssetsExcludingGoodwill = table.Column<long>(type: "bigint", nullable: true),
                    Goodwill = table.Column<long>(type: "bigint", nullable: true),
                    Investments = table.Column<long>(type: "bigint", nullable: true),
                    LongTermInvestments = table.Column<long>(type: "bigint", nullable: true),
                    ShortTermInvestments = table.Column<long>(type: "bigint", nullable: true),
                    OtherCurrentAssets = table.Column<long>(type: "bigint", nullable: true),
                    OtherNonCurrentAssets = table.Column<long>(type: "bigint", nullable: true),
                    TotalLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    TotalCurrentLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    CurrentAccountsPayable = table.Column<long>(type: "bigint", nullable: true),
                    DeferredRevenue = table.Column<long>(type: "bigint", nullable: true),
                    CurrentDebt = table.Column<long>(type: "bigint", nullable: true),
                    ShortTermDebt = table.Column<long>(type: "bigint", nullable: true),
                    TotalNonCurrentLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    CapitalLeaseObligations = table.Column<long>(type: "bigint", nullable: true),
                    LongTermDebt = table.Column<long>(type: "bigint", nullable: true),
                    CurrentLongTermDebt = table.Column<long>(type: "bigint", nullable: true),
                    LongTermDebtNoncurrent = table.Column<long>(type: "bigint", nullable: true),
                    ShortLongTermDebtTotal = table.Column<long>(type: "bigint", nullable: true),
                    OtherCurrentLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    OtherNonCurrentLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    TotalShareholderEquity = table.Column<long>(type: "bigint", nullable: true),
                    TreasuryStock = table.Column<long>(type: "bigint", nullable: true),
                    RetainedEarnings = table.Column<long>(type: "bigint", nullable: true),
                    CommonStock = table.Column<long>(type: "bigint", nullable: true),
                    CommonStockSharesOutstanding = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceSheetAnnualReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BalanceSheetAnnualReport_BalanceSheets_Symbol",
                        column: x => x.Symbol,
                        principalTable: "BalanceSheets",
                        principalColumn: "Symbol");
                });

            migrationBuilder.CreateTable(
                name: "BalanceSheetQuarterlyReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FiscalDateEnding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAssets = table.Column<long>(type: "bigint", nullable: true),
                    TotalCurrentAssets = table.Column<long>(type: "bigint", nullable: true),
                    CashAndCashEquivalentsAtCarryingValue = table.Column<long>(type: "bigint", nullable: true),
                    CashAndShortTermInvestments = table.Column<long>(type: "bigint", nullable: true),
                    Inventory = table.Column<long>(type: "bigint", nullable: true),
                    CurrentNetReceivables = table.Column<long>(type: "bigint", nullable: true),
                    TotalNonCurrentAssets = table.Column<long>(type: "bigint", nullable: true),
                    PropertyPlantEquipment = table.Column<long>(type: "bigint", nullable: true),
                    AccumulatedDepreciationAmortizationPPE = table.Column<long>(type: "bigint", nullable: true),
                    IntangibleAssets = table.Column<long>(type: "bigint", nullable: true),
                    IntangibleAssetsExcludingGoodwill = table.Column<long>(type: "bigint", nullable: true),
                    Goodwill = table.Column<long>(type: "bigint", nullable: true),
                    Investments = table.Column<long>(type: "bigint", nullable: true),
                    LongTermInvestments = table.Column<long>(type: "bigint", nullable: true),
                    ShortTermInvestments = table.Column<long>(type: "bigint", nullable: true),
                    OtherCurrentAssets = table.Column<long>(type: "bigint", nullable: true),
                    OtherNonCurrentAssets = table.Column<long>(type: "bigint", nullable: true),
                    TotalLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    TotalCurrentLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    CurrentAccountsPayable = table.Column<long>(type: "bigint", nullable: true),
                    DeferredRevenue = table.Column<long>(type: "bigint", nullable: true),
                    CurrentDebt = table.Column<long>(type: "bigint", nullable: true),
                    ShortTermDebt = table.Column<long>(type: "bigint", nullable: true),
                    TotalNonCurrentLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    CapitalLeaseObligations = table.Column<long>(type: "bigint", nullable: true),
                    LongTermDebt = table.Column<long>(type: "bigint", nullable: true),
                    CurrentLongTermDebt = table.Column<long>(type: "bigint", nullable: true),
                    LongTermDebtNoncurrent = table.Column<long>(type: "bigint", nullable: true),
                    ShortLongTermDebtTotal = table.Column<long>(type: "bigint", nullable: true),
                    OtherCurrentLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    OtherNonCurrentLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    TotalShareholderEquity = table.Column<long>(type: "bigint", nullable: true),
                    TreasuryStock = table.Column<long>(type: "bigint", nullable: true),
                    RetainedEarnings = table.Column<long>(type: "bigint", nullable: true),
                    CommonStock = table.Column<long>(type: "bigint", nullable: true),
                    CommonStockSharesOutstanding = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceSheetQuarterlyReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BalanceSheetQuarterlyReports_BalanceSheets_Symbol",
                        column: x => x.Symbol,
                        principalTable: "BalanceSheets",
                        principalColumn: "Symbol");
                });

            migrationBuilder.CreateTable(
                name: "IncomeStatementAnnualReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FiscalDateEnding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossProfit = table.Column<long>(type: "bigint", nullable: true),
                    TotalRevenue = table.Column<long>(type: "bigint", nullable: true),
                    CostOfRevenue = table.Column<long>(type: "bigint", nullable: true),
                    CostofGoodsAndServicesSold = table.Column<long>(type: "bigint", nullable: true),
                    OperatingIncome = table.Column<long>(type: "bigint", nullable: true),
                    SellingGeneralAndAdministrative = table.Column<long>(type: "bigint", nullable: true),
                    ResearchAndDevelopment = table.Column<long>(type: "bigint", nullable: true),
                    OperatingExpenses = table.Column<long>(type: "bigint", nullable: true),
                    InvestmentIncomeNet = table.Column<long>(type: "bigint", nullable: true),
                    NetInterestIncome = table.Column<long>(type: "bigint", nullable: true),
                    InterestIncome = table.Column<long>(type: "bigint", nullable: true),
                    InterestExpense = table.Column<long>(type: "bigint", nullable: true),
                    NonInterestIncome = table.Column<long>(type: "bigint", nullable: true),
                    OtherNonOperatingIncome = table.Column<long>(type: "bigint", nullable: true),
                    Depreciation = table.Column<long>(type: "bigint", nullable: true),
                    DepreciationAndAmortization = table.Column<long>(type: "bigint", nullable: true),
                    IncomeBeforeTax = table.Column<long>(type: "bigint", nullable: true),
                    IncomeTaxExpense = table.Column<long>(type: "bigint", nullable: true),
                    InterestAndDebtExpense = table.Column<long>(type: "bigint", nullable: true),
                    NetIncomeFromContinuingOperations = table.Column<long>(type: "bigint", nullable: true),
                    ComprehensiveIncomeNetOfTax = table.Column<long>(type: "bigint", nullable: true),
                    Ebit = table.Column<long>(type: "bigint", nullable: true),
                    Ebitda = table.Column<long>(type: "bigint", nullable: true),
                    NetIncome = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeStatementAnnualReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeStatementAnnualReport_IncomeStatements_Symbol",
                        column: x => x.Symbol,
                        principalTable: "IncomeStatements",
                        principalColumn: "Symbol");
                });

            migrationBuilder.CreateTable(
                name: "IncomeStatementQuarterlyReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FiscalDateEnding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportedCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossProfit = table.Column<long>(type: "bigint", nullable: true),
                    TotalRevenue = table.Column<long>(type: "bigint", nullable: true),
                    CostOfRevenue = table.Column<long>(type: "bigint", nullable: true),
                    CostofGoodsAndServicesSold = table.Column<long>(type: "bigint", nullable: true),
                    OperatingIncome = table.Column<long>(type: "bigint", nullable: true),
                    SellingGeneralAndAdministrative = table.Column<long>(type: "bigint", nullable: true),
                    ResearchAndDevelopment = table.Column<long>(type: "bigint", nullable: true),
                    OperatingExpenses = table.Column<long>(type: "bigint", nullable: true),
                    InvestmentIncomeNet = table.Column<long>(type: "bigint", nullable: true),
                    NetInterestIncome = table.Column<long>(type: "bigint", nullable: true),
                    InterestIncome = table.Column<long>(type: "bigint", nullable: true),
                    InterestExpense = table.Column<long>(type: "bigint", nullable: true),
                    NonInterestIncome = table.Column<long>(type: "bigint", nullable: true),
                    OtherNonOperatingIncome = table.Column<long>(type: "bigint", nullable: true),
                    Depreciation = table.Column<long>(type: "bigint", nullable: true),
                    DepreciationAndAmortization = table.Column<long>(type: "bigint", nullable: true),
                    IncomeBeforeTax = table.Column<long>(type: "bigint", nullable: true),
                    IncomeTaxExpense = table.Column<long>(type: "bigint", nullable: true),
                    InterestAndDebtExpense = table.Column<long>(type: "bigint", nullable: true),
                    NetIncomeFromContinuingOperations = table.Column<long>(type: "bigint", nullable: true),
                    ComprehensiveIncomeNetOfTax = table.Column<long>(type: "bigint", nullable: true),
                    Ebit = table.Column<long>(type: "bigint", nullable: true),
                    Ebitda = table.Column<long>(type: "bigint", nullable: true),
                    NetIncome = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeStatementQuarterlyReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeStatementQuarterlyReport_IncomeStatements_Symbol",
                        column: x => x.Symbol,
                        principalTable: "IncomeStatements",
                        principalColumn: "Symbol");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowReport_Symbol",
                table: "CashFlowReport",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceSheetAnnualReport_Symbol",
                table: "BalanceSheetAnnualReport",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceSheetQuarterlyReports_Symbol",
                table: "BalanceSheetQuarterlyReports",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeStatementAnnualReport_Symbol",
                table: "IncomeStatementAnnualReport",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeStatementQuarterlyReport_Symbol",
                table: "IncomeStatementQuarterlyReport",
                column: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlowReport_CashFlows_Symbol",
                table: "CashFlowReport",
                column: "Symbol",
                principalTable: "CashFlows",
                principalColumn: "Symbol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CashFlowReport_CashFlows_Symbol",
                table: "CashFlowReport");

            migrationBuilder.DropTable(
                name: "BalanceSheetAnnualReport");

            migrationBuilder.DropTable(
                name: "BalanceSheetQuarterlyReports");

            migrationBuilder.DropTable(
                name: "IncomeStatementAnnualReport");

            migrationBuilder.DropTable(
                name: "IncomeStatementQuarterlyReport");

            migrationBuilder.DropIndex(
                name: "IX_CashFlowReport_Symbol",
                table: "CashFlowReport");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CashFlowReport");

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "CashFlowReport",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CashFlowSymbol1",
                table: "CashFlowReport",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BalanceSheetReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccumulatedDepreciationAmortizationPPE = table.Column<long>(type: "bigint", nullable: true),
                    BalanceSheetSymbol = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CapitalLeaseObligations = table.Column<long>(type: "bigint", nullable: true),
                    CashAndCashEquivalentsAtCarryingValue = table.Column<long>(type: "bigint", nullable: true),
                    CashAndShortTermInvestments = table.Column<long>(type: "bigint", nullable: true),
                    CommonStock = table.Column<long>(type: "bigint", nullable: true),
                    CommonStockSharesOutstanding = table.Column<long>(type: "bigint", nullable: true),
                    CurrentAccountsPayable = table.Column<long>(type: "bigint", nullable: true),
                    CurrentDebt = table.Column<long>(type: "bigint", nullable: true),
                    CurrentLongTermDebt = table.Column<long>(type: "bigint", nullable: true),
                    CurrentNetReceivables = table.Column<long>(type: "bigint", nullable: true),
                    DeferredRevenue = table.Column<long>(type: "bigint", nullable: true),
                    FiscalDateEnding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Goodwill = table.Column<long>(type: "bigint", nullable: true),
                    IntangibleAssets = table.Column<long>(type: "bigint", nullable: true),
                    IntangibleAssetsExcludingGoodwill = table.Column<long>(type: "bigint", nullable: true),
                    Inventory = table.Column<long>(type: "bigint", nullable: true),
                    Investments = table.Column<long>(type: "bigint", nullable: true),
                    LongTermDebt = table.Column<long>(type: "bigint", nullable: true),
                    LongTermDebtNoncurrent = table.Column<long>(type: "bigint", nullable: true),
                    LongTermInvestments = table.Column<long>(type: "bigint", nullable: true),
                    OtherCurrentAssets = table.Column<long>(type: "bigint", nullable: true),
                    OtherCurrentLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    OtherNonCurrentAssets = table.Column<long>(type: "bigint", nullable: true),
                    OtherNonCurrentLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    PropertyPlantEquipment = table.Column<long>(type: "bigint", nullable: true),
                    ReportedCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetainedEarnings = table.Column<long>(type: "bigint", nullable: true),
                    ShortLongTermDebtTotal = table.Column<long>(type: "bigint", nullable: true),
                    ShortTermDebt = table.Column<long>(type: "bigint", nullable: true),
                    ShortTermInvestments = table.Column<long>(type: "bigint", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalAssets = table.Column<long>(type: "bigint", nullable: true),
                    TotalCurrentAssets = table.Column<long>(type: "bigint", nullable: true),
                    TotalCurrentLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    TotalLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    TotalNonCurrentAssets = table.Column<long>(type: "bigint", nullable: true),
                    TotalNonCurrentLiabilities = table.Column<long>(type: "bigint", nullable: true),
                    TotalShareholderEquity = table.Column<long>(type: "bigint", nullable: true),
                    TreasuryStock = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceSheetReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BalanceSheetReport_BalanceSheets_BalanceSheetSymbol",
                        column: x => x.BalanceSheetSymbol,
                        principalTable: "BalanceSheets",
                        principalColumn: "Symbol");
                    table.ForeignKey(
                        name: "FK_BalanceSheetReport_BalanceSheets_Symbol",
                        column: x => x.Symbol,
                        principalTable: "BalanceSheets",
                        principalColumn: "Symbol");
                });

            migrationBuilder.CreateTable(
                name: "IncomeStatementReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComprehensiveIncomeNetOfTax = table.Column<long>(type: "bigint", nullable: true),
                    CostOfRevenue = table.Column<long>(type: "bigint", nullable: true),
                    CostofGoodsAndServicesSold = table.Column<long>(type: "bigint", nullable: true),
                    Depreciation = table.Column<long>(type: "bigint", nullable: true),
                    DepreciationAndAmortization = table.Column<long>(type: "bigint", nullable: true),
                    Ebit = table.Column<long>(type: "bigint", nullable: true),
                    Ebitda = table.Column<long>(type: "bigint", nullable: true),
                    FiscalDateEnding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrossProfit = table.Column<long>(type: "bigint", nullable: true),
                    IncomeBeforeTax = table.Column<long>(type: "bigint", nullable: true),
                    IncomeStatementSymbol = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IncomeStatementSymbol1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IncomeTaxExpense = table.Column<long>(type: "bigint", nullable: true),
                    InterestAndDebtExpense = table.Column<long>(type: "bigint", nullable: true),
                    InterestExpense = table.Column<long>(type: "bigint", nullable: true),
                    InterestIncome = table.Column<long>(type: "bigint", nullable: true),
                    InvestmentIncomeNet = table.Column<long>(type: "bigint", nullable: true),
                    NetIncome = table.Column<long>(type: "bigint", nullable: true),
                    NetIncomeFromContinuingOperations = table.Column<long>(type: "bigint", nullable: true),
                    NetInterestIncome = table.Column<long>(type: "bigint", nullable: true),
                    NonInterestIncome = table.Column<long>(type: "bigint", nullable: true),
                    OperatingExpenses = table.Column<long>(type: "bigint", nullable: true),
                    OperatingIncome = table.Column<long>(type: "bigint", nullable: true),
                    OtherNonOperatingIncome = table.Column<long>(type: "bigint", nullable: true),
                    ReportedCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearchAndDevelopment = table.Column<long>(type: "bigint", nullable: true),
                    SellingGeneralAndAdministrative = table.Column<long>(type: "bigint", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRevenue = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeStatementReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeStatementReport_IncomeStatements_IncomeStatementSymbol",
                        column: x => x.IncomeStatementSymbol,
                        principalTable: "IncomeStatements",
                        principalColumn: "Symbol");
                    table.ForeignKey(
                        name: "FK_IncomeStatementReport_IncomeStatements_IncomeStatementSymbol1",
                        column: x => x.IncomeStatementSymbol1,
                        principalTable: "IncomeStatements",
                        principalColumn: "Symbol");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowReport_CashFlowSymbol1",
                table: "CashFlowReport",
                column: "CashFlowSymbol1");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceSheetReport_BalanceSheetSymbol",
                table: "BalanceSheetReport",
                column: "BalanceSheetSymbol");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceSheetReport_Symbol",
                table: "BalanceSheetReport",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeStatementReport_IncomeStatementSymbol",
                table: "IncomeStatementReport",
                column: "IncomeStatementSymbol");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeStatementReport_IncomeStatementSymbol1",
                table: "IncomeStatementReport",
                column: "IncomeStatementSymbol1");

            migrationBuilder.AddForeignKey(
                name: "FK_CashFlowReport_CashFlows_CashFlowSymbol1",
                table: "CashFlowReport",
                column: "CashFlowSymbol1",
                principalTable: "CashFlows",
                principalColumn: "Symbol");
        }
    }
}
