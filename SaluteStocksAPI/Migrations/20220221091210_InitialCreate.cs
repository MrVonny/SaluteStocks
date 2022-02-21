using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaluteStocksAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BalanceSheets",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastLocalRefresh = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastApiRefresh = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceSheets", x => x.Symbol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CashFlows",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastLocalRefresh = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastApiRefresh = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashFlows", x => x.Symbol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CompanyOverviews",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssetType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CIK = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Exchange = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Currency = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sector = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Industry = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FiscalYearEnd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LatestQuarter = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MarketCapitalization = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EBITDA = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PERatio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PEGRatio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DividendPerShare = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DividendYield = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EPS = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RevenuePerShareTTM = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfitMargin = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OperatingMarginTTM = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReturnOnAssetsTTM = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReturnOnEquityTTM = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RevenueTTM = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GrossProfitTTM = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DilutedEPSTTM = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuarterlyEarningsGrowthYOY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuarterlyRevenueGrowthYOY = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnalystTargetPrice = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrailingPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ForwardPE = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PriceToSalesRatioTTM = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PriceToBookRatio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EVToRevenue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EVToEBITDA = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Beta = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    _52WeekHigh = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    _52WeekLow = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    _50DayMovingAverage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    _200DayMovingAverage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SharesOutstanding = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DividendDate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExDividendDate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastLocalRefresh = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastApiRefresh = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyOverviews", x => x.Symbol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Earnings",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastLocalRefresh = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastApiRefresh = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Earnings", x => x.Symbol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IncomeStatements",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastLocalRefresh = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastApiRefresh = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeStatements", x => x.Symbol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Listing",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Exchange = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssetType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IpoDate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DelistingDate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    LastLocalRefresh = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastApiRefresh = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listing", x => x.Symbol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BalanceSheetReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TotalAssets = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    TotalCurrentAssets = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CashAndCashEquivalentsAtCarryingValue = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CashAndShortTermInvestments = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    Inventory = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CurrentNetReceivables = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    TotalNonCurrentAssets = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    PropertyPlantEquipment = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    AccumulatedDepreciationAmortizationPPE = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    IntangibleAssets = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    IntangibleAssetsExcludingGoodwill = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    Goodwill = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    Investments = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    LongTermInvestments = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    ShortTermInvestments = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    OtherCurrentAssets = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    OtherNonCurrentAssets = table.Column<long>(type: "bigint", nullable: false),
                    TotalLiabilities = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    TotalCurrentLiabilities = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CurrentAccountsPayable = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    DeferredRevenue = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CurrentDebt = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    ShortTermDebt = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    TotalNonCurrentLiabilities = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CapitalLeaseObligations = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    LongTermDebt = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CurrentLongTermDebt = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    LongTermDebtNoncurrent = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    ShortLongTermDebtTotal = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    OtherCurrentLiabilities = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    OtherNonCurrentLiabilities = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    TotalShareholderEquity = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    TreasuryStock = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    RetainedEarnings = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CommonStock = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    CommonStockSharesOutstanding = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    BalanceSheetSymbol = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FiscalDateEnding = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReportedCurrency = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CashFlowReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OperatingCashFlow = table.Column<long>(type: "bigint", nullable: false),
                    PaymentsForOperatingActivities = table.Column<long>(type: "bigint", nullable: false),
                    ProceedsFromOperatingActivities = table.Column<long>(type: "bigint", nullable: false),
                    ChangeInOperatingLiabilities = table.Column<long>(type: "bigint", nullable: false),
                    ChangeInOperatingAssets = table.Column<long>(type: "bigint", nullable: false),
                    DepreciationDepletionAndAmortization = table.Column<long>(type: "bigint", nullable: false),
                    CapitalExpenditures = table.Column<long>(type: "bigint", nullable: false),
                    ChangeInReceivables = table.Column<long>(type: "bigint", nullable: false),
                    ChangeInInventory = table.Column<long>(type: "bigint", nullable: false),
                    ProfitLoss = table.Column<long>(type: "bigint", nullable: false),
                    CashflowFromInvestment = table.Column<long>(type: "bigint", nullable: false),
                    CashflowFromFinancing = table.Column<long>(type: "bigint", nullable: false),
                    ProceedsFromRepaymentsOfShortTermDebt = table.Column<long>(type: "bigint", nullable: false),
                    PaymentsForRepurchaseOfCommonStock = table.Column<long>(type: "bigint", nullable: false),
                    PaymentsForRepurchaseOfEquity = table.Column<long>(type: "bigint", nullable: false),
                    PaymentsForRepurchaseOfPreferredStock = table.Column<long>(type: "bigint", nullable: false),
                    DividendPayout = table.Column<long>(type: "bigint", nullable: false),
                    DividendPayoutCommonStock = table.Column<long>(type: "bigint", nullable: false),
                    DividendPayoutPreferredStock = table.Column<long>(type: "bigint", nullable: false),
                    ProceedsFromIssuanceOfCommonStock = table.Column<long>(type: "bigint", nullable: false),
                    ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet = table.Column<long>(type: "bigint", nullable: false),
                    ProceedsFromIssuanceOfPreferredStock = table.Column<long>(type: "bigint", nullable: false),
                    ProceedsFromRepurchaseOfEquity = table.Column<long>(type: "bigint", nullable: false),
                    ProceedsFromSaleOfTreasuryStock = table.Column<long>(type: "bigint", nullable: false),
                    ChangeInCashAndCashEquivalents = table.Column<long>(type: "bigint", nullable: false),
                    ChangeInExchangeRate = table.Column<long>(type: "bigint", nullable: false),
                    NetIncome = table.Column<long>(type: "bigint", nullable: false),
                    CashFlowSymbol = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FiscalDateEnding = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReportedCurrency = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                        name: "FK_CashFlowReport_CashFlows_Symbol",
                        column: x => x.Symbol,
                        principalTable: "CashFlows",
                        principalColumn: "Symbol");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AnnualEarning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FiscalDateEnding = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReportedEPS = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualEarning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualEarning_Earnings_Symbol",
                        column: x => x.Symbol,
                        principalTable: "Earnings",
                        principalColumn: "Symbol");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuarterlyEarning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FiscalDateEnding = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReportedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ReportedEPS = table.Column<double>(type: "double", nullable: false),
                    EstimatedEPS = table.Column<double>(type: "double", nullable: false),
                    Surprise = table.Column<double>(type: "double", nullable: false),
                    SurprisePercentage = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuarterlyEarning", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuarterlyEarning_Earnings_Symbol",
                        column: x => x.Symbol,
                        principalTable: "Earnings",
                        principalColumn: "Symbol");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IncomeStatementReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GrossProfit = table.Column<long>(type: "bigint", nullable: false),
                    TotalRevenue = table.Column<long>(type: "bigint", nullable: false),
                    CostOfRevenue = table.Column<long>(type: "bigint", nullable: false),
                    CostofGoodsAndServicesSold = table.Column<long>(type: "bigint", nullable: false),
                    OperatingIncome = table.Column<long>(type: "bigint", nullable: false),
                    SellingGeneralAndAdministrative = table.Column<long>(type: "bigint", nullable: false),
                    ResearchAndDevelopment = table.Column<long>(type: "bigint", nullable: false),
                    OperatingExpenses = table.Column<long>(type: "bigint", nullable: false),
                    InvestmentIncomeNet = table.Column<long>(type: "bigint", nullable: false),
                    NetInterestIncome = table.Column<long>(type: "bigint", nullable: false),
                    InterestIncome = table.Column<long>(type: "bigint", nullable: false),
                    InterestExpense = table.Column<long>(type: "bigint", nullable: false),
                    NonInterestIncome = table.Column<long>(type: "bigint", nullable: false),
                    OtherNonOperatingIncome = table.Column<long>(type: "bigint", nullable: false),
                    Depreciation = table.Column<long>(type: "bigint", nullable: false),
                    DepreciationAndAmortization = table.Column<long>(type: "bigint", nullable: false),
                    IncomeBeforeTax = table.Column<long>(type: "bigint", nullable: false),
                    IncomeTaxExpense = table.Column<long>(type: "bigint", nullable: false),
                    InterestAndDebtExpense = table.Column<long>(type: "bigint", nullable: false),
                    NetIncomeFromContinuingOperations = table.Column<long>(type: "bigint", nullable: false),
                    ComprehensiveIncomeNetOfTax = table.Column<long>(type: "bigint", nullable: false),
                    Ebit = table.Column<long>(type: "bigint", nullable: false),
                    Ebitda = table.Column<long>(type: "bigint", nullable: false),
                    NetIncome = table.Column<long>(type: "bigint", nullable: false),
                    IncomeStatementSymbol = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Symbol = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FiscalDateEnding = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReportedCurrency = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                        name: "FK_IncomeStatementReport_IncomeStatements_Symbol",
                        column: x => x.Symbol,
                        principalTable: "IncomeStatements",
                        principalColumn: "Symbol");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualEarning_Symbol",
                table: "AnnualEarning",
                column: "Symbol");

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
                name: "IX_CashFlowReport_Symbol",
                table: "CashFlowReport",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeStatementReport_IncomeStatementSymbol",
                table: "IncomeStatementReport",
                column: "IncomeStatementSymbol");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeStatementReport_Symbol",
                table: "IncomeStatementReport",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_QuarterlyEarning_Symbol",
                table: "QuarterlyEarning",
                column: "Symbol");
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
