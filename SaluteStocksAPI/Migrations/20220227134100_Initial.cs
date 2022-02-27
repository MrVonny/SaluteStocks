using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaluteStocksAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalanceSheets",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastLocalRefresh = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    LastApiRefresh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceSheets", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "CashFlows",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastLocalRefresh = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    LastApiRefresh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlows", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "Earnings",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastLocalRefresh = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    LastApiRefresh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Earnings", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "IncomeStatements",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastLocalRefresh = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    LastApiRefresh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeStatements", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exchange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpoDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelistingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LastLocalRefresh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastApiRefresh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "BalanceSheetReport",
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
                    CommonStockSharesOutstanding = table.Column<long>(type: "bigint", nullable: true),
                    BalanceSheetSymbol = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                name: "CashFlowReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    NetIncome = table.Column<long>(type: "bigint", nullable: true),
                    CashFlowSymbol = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CashFlowSymbol1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlowReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashFlowReport_CashFlows_CashFlowSymbol",
                        column: x => x.CashFlowSymbol,
                        principalTable: "CashFlows",
                        principalColumn: "Symbol");
                    table.ForeignKey(
                        name: "FK_CashFlowReport_CashFlows_CashFlowSymbol1",
                        column: x => x.CashFlowSymbol1,
                        principalTable: "CashFlows",
                        principalColumn: "Symbol");
                });

            migrationBuilder.CreateTable(
                name: "AnnualEarning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalDateEnding = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportedEPS = table.Column<double>(type: "float", nullable: true),
                    EarningsSymbol = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualEarning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualEarning_Earnings_EarningsSymbol",
                        column: x => x.EarningsSymbol,
                        principalTable: "Earnings",
                        principalColumn: "Symbol");
                });

            migrationBuilder.CreateTable(
                name: "QuarterlyEarning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalDateEnding = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReportedEPS = table.Column<double>(type: "float", nullable: true),
                    EstimatedEPS = table.Column<double>(type: "float", nullable: true),
                    Surprise = table.Column<double>(type: "float", nullable: true),
                    SurprisePercentage = table.Column<double>(type: "float", nullable: true),
                    EarningsSymbol = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarterlyEarning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuarterlyEarning_Earnings_EarningsSymbol",
                        column: x => x.EarningsSymbol,
                        principalTable: "Earnings",
                        principalColumn: "Symbol");
                });

            migrationBuilder.CreateTable(
                name: "CompanyOverviews",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AssetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIK = table.Column<long>(type: "bigint", nullable: true),
                    Exchange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalYearEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LatestQuarter = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MarketCapitalization = table.Column<long>(type: "bigint", nullable: true),
                    EBITDA = table.Column<long>(type: "bigint", nullable: true),
                    PERatio = table.Column<double>(type: "float", nullable: true),
                    PEGRatio = table.Column<double>(type: "float", nullable: true),
                    BookValue = table.Column<double>(type: "float", nullable: true),
                    DividendPerShare = table.Column<double>(type: "float", nullable: true),
                    DividendYield = table.Column<double>(type: "float", nullable: true),
                    EPS = table.Column<double>(type: "float", nullable: true),
                    RevenuePerShareTTM = table.Column<double>(type: "float", nullable: true),
                    ProfitMargin = table.Column<double>(type: "float", nullable: true),
                    OperatingMarginTTM = table.Column<double>(type: "float", nullable: true),
                    ReturnOnAssetsTTM = table.Column<double>(type: "float", nullable: true),
                    ReturnOnEquityTTM = table.Column<double>(type: "float", nullable: true),
                    RevenueTTM = table.Column<long>(type: "bigint", nullable: true),
                    GrossProfitTTM = table.Column<long>(type: "bigint", nullable: true),
                    DilutedEPSTTM = table.Column<double>(type: "float", nullable: true),
                    QuarterlyEarningsGrowthYOY = table.Column<double>(type: "float", nullable: true),
                    QuarterlyRevenueGrowthYOY = table.Column<double>(type: "float", nullable: true),
                    AnalystTargetPrice = table.Column<double>(type: "float", nullable: true),
                    TrailingPE = table.Column<double>(type: "float", nullable: true),
                    ForwardPE = table.Column<double>(type: "float", nullable: true),
                    PriceToSalesRatioTTM = table.Column<double>(type: "float", nullable: true),
                    PriceToBookRatio = table.Column<double>(type: "float", nullable: true),
                    EVToRevenue = table.Column<double>(type: "float", nullable: true),
                    EVToEBITDA = table.Column<double>(type: "float", nullable: true),
                    Beta = table.Column<double>(type: "float", nullable: true),
                    _52WeekHigh = table.Column<double>(type: "float", nullable: true),
                    _52WeekLow = table.Column<double>(type: "float", nullable: true),
                    _50DayMovingAverage = table.Column<double>(type: "float", nullable: true),
                    _200DayMovingAverage = table.Column<double>(type: "float", nullable: true),
                    SharesOutstanding = table.Column<long>(type: "bigint", nullable: true),
                    DividendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExDividendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastLocalRefresh = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    LastApiRefresh = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOverviews", x => x.Symbol);
                    table.ForeignKey(
                        name: "FK_CompanyOverviews_BalanceSheets_Symbol",
                        column: x => x.Symbol,
                        principalTable: "BalanceSheets",
                        principalColumn: "Symbol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyOverviews_CashFlows_Symbol",
                        column: x => x.Symbol,
                        principalTable: "CashFlows",
                        principalColumn: "Symbol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyOverviews_Earnings_Symbol",
                        column: x => x.Symbol,
                        principalTable: "Earnings",
                        principalColumn: "Symbol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyOverviews_IncomeStatements_Symbol",
                        column: x => x.Symbol,
                        principalTable: "IncomeStatements",
                        principalColumn: "Symbol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncomeStatementReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    NetIncome = table.Column<long>(type: "bigint", nullable: true),
                    IncomeStatementSymbol = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IncomeStatementSymbol1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                name: "IX_AnnualEarning_EarningsSymbol",
                table: "AnnualEarning",
                column: "EarningsSymbol");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceSheetReport_BalanceSheetSymbol",
                table: "BalanceSheetReport",
                column: "BalanceSheetSymbol");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceSheetReport_Symbol",
                table: "BalanceSheetReport",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowReport_CashFlowSymbol",
                table: "CashFlowReport",
                column: "CashFlowSymbol");

            migrationBuilder.CreateIndex(
                name: "IX_CashFlowReport_CashFlowSymbol1",
                table: "CashFlowReport",
                column: "CashFlowSymbol1");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeStatementReport_IncomeStatementSymbol",
                table: "IncomeStatementReport",
                column: "IncomeStatementSymbol");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeStatementReport_IncomeStatementSymbol1",
                table: "IncomeStatementReport",
                column: "IncomeStatementSymbol1");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterlyEarning_EarningsSymbol",
                table: "QuarterlyEarning",
                column: "EarningsSymbol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnualEarning");

            migrationBuilder.DropTable(
                name: "BalanceSheetReport");

            migrationBuilder.DropTable(
                name: "CashFlowReport");

            migrationBuilder.DropTable(
                name: "CompanyOverviews");

            migrationBuilder.DropTable(
                name: "IncomeStatementReport");

            migrationBuilder.DropTable(
                name: "Listing");

            migrationBuilder.DropTable(
                name: "QuarterlyEarning");

            migrationBuilder.DropTable(
                name: "BalanceSheets");

            migrationBuilder.DropTable(
                name: "CashFlows");

            migrationBuilder.DropTable(
                name: "IncomeStatements");

            migrationBuilder.DropTable(
                name: "Earnings");
        }
    }
}
