using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaluteStocksAPI.Migrations
{
    public partial class CompanyOverviewNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SurprisePercentage",
                table: "QuarterlyEarning",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<double>(
                name: "Surprise",
                table: "QuarterlyEarning",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<double>(
                name: "ReportedEPS",
                table: "QuarterlyEarning",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportedDate",
                table: "QuarterlyEarning",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FiscalDateEnding",
                table: "QuarterlyEarning",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<double>(
                name: "EstimatedEPS",
                table: "QuarterlyEarning",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<long>(
                name: "TotalRevenue",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "SellingGeneralAndAdministrative",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ResearchAndDevelopment",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "OtherNonOperatingIncome",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "OperatingIncome",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "OperatingExpenses",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "NonInterestIncome",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "NetInterestIncome",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "NetIncomeFromContinuingOperations",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "NetIncome",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "InvestmentIncomeNet",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "InterestIncome",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "InterestExpense",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "InterestAndDebtExpense",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "IncomeTaxExpense",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "IncomeBeforeTax",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "GrossProfit",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "Ebitda",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "Ebit",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DepreciationAndAmortization",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "Depreciation",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CostofGoodsAndServicesSold",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CostOfRevenue",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ComprehensiveIncomeNetOfTax",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<double>(
                name: "_52WeekLow",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "_52WeekHigh",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "_50DayMovingAverage",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "_200DayMovingAverage",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "TrailingPE",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "SharesOutstanding",
                table: "CompanyOverviews",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "RevenueTTM",
                table: "CompanyOverviews",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "RevenuePerShareTTM",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "ReturnOnEquityTTM",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "ReturnOnAssetsTTM",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "QuarterlyRevenueGrowthYOY",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "QuarterlyEarningsGrowthYOY",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "ProfitMargin",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "PriceToSalesRatioTTM",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "PriceToBookRatio",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "PERatio",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "PEGRatio",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "OperatingMarginTTM",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "MarketCapitalization",
                table: "CompanyOverviews",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LatestQuarter",
                table: "CompanyOverviews",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "GrossProfitTTM",
                table: "CompanyOverviews",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "ForwardPE",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExDividendDate",
                table: "CompanyOverviews",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "EVToRevenue",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "EVToEBITDA",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "EPS",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "EBITDA",
                table: "CompanyOverviews",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "DividendYield",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "DividendPerShare",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DividendDate",
                table: "CompanyOverviews",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "DilutedEPSTTM",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "CIK",
                table: "CompanyOverviews",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "BookValue",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "Beta",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<double>(
                name: "AnalystTargetPrice",
                table: "CompanyOverviews",
                type: "double",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "ProfitLoss",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromSaleOfTreasuryStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromRepurchaseOfEquity",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromRepaymentsOfShortTermDebt",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromOperatingActivities",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromIssuanceOfPreferredStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromIssuanceOfCommonStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PaymentsForRepurchaseOfPreferredStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PaymentsForRepurchaseOfEquity",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PaymentsForRepurchaseOfCommonStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PaymentsForOperatingActivities",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "OperatingCashFlow",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "NetIncome",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DividendPayoutPreferredStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DividendPayoutCommonStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DividendPayout",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DepreciationDepletionAndAmortization",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInReceivables",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInOperatingLiabilities",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInOperatingAssets",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInInventory",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInExchangeRate",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInCashAndCashEquivalents",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CashflowFromInvestment",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CashflowFromFinancing",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CapitalExpenditures",
                table: "CashFlowReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "TreasuryStock",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "TotalShareholderEquity",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "TotalNonCurrentLiabilities",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "TotalNonCurrentAssets",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "TotalLiabilities",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "TotalCurrentLiabilities",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "TotalCurrentAssets",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "TotalAssets",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "ShortTermInvestments",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "ShortTermDebt",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "ShortLongTermDebtTotal",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "RetainedEarnings",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "PropertyPlantEquipment",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "OtherNonCurrentLiabilities",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "OtherNonCurrentAssets",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "OtherCurrentLiabilities",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "OtherCurrentAssets",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "LongTermInvestments",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "LongTermDebtNoncurrent",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "LongTermDebt",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "Investments",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "Inventory",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "IntangibleAssetsExcludingGoodwill",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "IntangibleAssets",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "Goodwill",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "DeferredRevenue",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "CurrentNetReceivables",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "CurrentLongTermDebt",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "CurrentDebt",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "CurrentAccountsPayable",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "CommonStockSharesOutstanding",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "CommonStock",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "CashAndShortTermInvestments",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "CashAndCashEquivalentsAtCarryingValue",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "CapitalLeaseObligations",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<long>(
                name: "AccumulatedDepreciationAmortizationPPE",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AlterColumn<double>(
                name: "ReportedEPS",
                table: "AnnualEarning",
                type: "double",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FiscalDateEnding",
                table: "AnnualEarning",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "SurprisePercentage",
                table: "QuarterlyEarning",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Surprise",
                table: "QuarterlyEarning",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ReportedEPS",
                table: "QuarterlyEarning",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportedDate",
                table: "QuarterlyEarning",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FiscalDateEnding",
                table: "QuarterlyEarning",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "EstimatedEPS",
                table: "QuarterlyEarning",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TotalRevenue",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SellingGeneralAndAdministrative",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ResearchAndDevelopment",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OtherNonOperatingIncome",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OperatingIncome",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OperatingExpenses",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NonInterestIncome",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NetInterestIncome",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NetIncomeFromContinuingOperations",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NetIncome",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InvestmentIncomeNet",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InterestIncome",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InterestExpense",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InterestAndDebtExpense",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IncomeTaxExpense",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IncomeBeforeTax",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "GrossProfit",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Ebitda",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Ebit",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DepreciationAndAmortization",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Depreciation",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CostofGoodsAndServicesSold",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CostOfRevenue",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ComprehensiveIncomeNetOfTax",
                table: "IncomeStatementReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "_52WeekLow",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "_52WeekHigh",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "_50DayMovingAverage",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "_200DayMovingAverage",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TrailingPE",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "SharesOutstanding",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "RevenueTTM",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "RevenuePerShareTTM",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ReturnOnEquityTTM",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ReturnOnAssetsTTM",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "QuarterlyRevenueGrowthYOY",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "QuarterlyEarningsGrowthYOY",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ProfitMargin",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PriceToSalesRatioTTM",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PriceToBookRatio",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PERatio",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PEGRatio",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "OperatingMarginTTM",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "MarketCapitalization",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LatestQuarter",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "GrossProfitTTM",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ForwardPE",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ExDividendDate",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EVToRevenue",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EVToEBITDA",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EPS",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EBITDA",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DividendYield",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DividendPerShare",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DividendDate",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "DilutedEPSTTM",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "CIK",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BookValue",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Beta",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AnalystTargetPrice",
                table: "CompanyOverviews",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<long>(
                name: "ProfitLoss",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromSaleOfTreasuryStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromRepurchaseOfEquity",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromRepaymentsOfShortTermDebt",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromOperatingActivities",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromIssuanceOfPreferredStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProceedsFromIssuanceOfCommonStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PaymentsForRepurchaseOfPreferredStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PaymentsForRepurchaseOfEquity",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PaymentsForRepurchaseOfCommonStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PaymentsForOperatingActivities",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OperatingCashFlow",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NetIncome",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DividendPayoutPreferredStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DividendPayoutCommonStock",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DividendPayout",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DepreciationDepletionAndAmortization",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInReceivables",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInOperatingLiabilities",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInOperatingAssets",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInInventory",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInExchangeRate",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ChangeInCashAndCashEquivalents",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CashflowFromInvestment",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CashflowFromFinancing",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CapitalExpenditures",
                table: "CashFlowReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "TreasuryStock",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "TotalShareholderEquity",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "TotalNonCurrentLiabilities",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "TotalNonCurrentAssets",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "TotalLiabilities",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "TotalCurrentLiabilities",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "TotalCurrentAssets",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "TotalAssets",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "ShortTermInvestments",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "ShortTermDebt",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "ShortLongTermDebtTotal",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "RetainedEarnings",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "PropertyPlantEquipment",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "OtherNonCurrentLiabilities",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "OtherNonCurrentAssets",
                table: "BalanceSheetReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "OtherCurrentLiabilities",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "OtherCurrentAssets",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "LongTermInvestments",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "LongTermDebtNoncurrent",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "LongTermDebt",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "Investments",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "Inventory",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "IntangibleAssetsExcludingGoodwill",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "IntangibleAssets",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "Goodwill",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "DeferredRevenue",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "CurrentNetReceivables",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "CurrentLongTermDebt",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "CurrentDebt",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "CurrentAccountsPayable",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "CommonStockSharesOutstanding",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "CommonStock",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "CashAndShortTermInvestments",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "CashAndCashEquivalentsAtCarryingValue",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "CapitalLeaseObligations",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "AccumulatedDepreciationAmortizationPPE",
                table: "BalanceSheetReport",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ReportedEPS",
                table: "AnnualEarning",
                type: "double",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FiscalDateEnding",
                table: "AnnualEarning",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}
