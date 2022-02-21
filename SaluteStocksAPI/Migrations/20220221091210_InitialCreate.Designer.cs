﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaluteStocksAPI.DataBase;

#nullable disable

namespace SaluteStocksAPI.Migrations
{
    [DbContext(typeof(StocksContext))]
    [Migration("20220221091210_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.AnnualEarning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FiscalDateEnding")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("ReportedEPS")
                        .HasColumnType("double");

                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Symbol");

                    b.ToTable("AnnualEarning");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.BalanceSheet", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("LastApiRefresh")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LastLocalRefresh")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Symbol");

                    b.ToTable("BalanceSheets");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.BalanceSheetReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("AccumulatedDepreciationAmortizationPPE")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("BalanceSheetSymbol")
                        .HasColumnType("varchar(255)");

                    b.Property<ulong>("CapitalLeaseObligations")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("CashAndCashEquivalentsAtCarryingValue")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("CashAndShortTermInvestments")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("CommonStock")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("CommonStockSharesOutstanding")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("CurrentAccountsPayable")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("CurrentDebt")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("CurrentLongTermDebt")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("CurrentNetReceivables")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("DeferredRevenue")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("FiscalDateEnding")
                        .HasColumnType("longtext");

                    b.Property<ulong>("Goodwill")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("IntangibleAssets")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("IntangibleAssetsExcludingGoodwill")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Inventory")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Investments")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("LongTermDebt")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("LongTermDebtNoncurrent")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("LongTermInvestments")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("OtherCurrentAssets")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("OtherCurrentLiabilities")
                        .HasColumnType("bigint unsigned");

                    b.Property<long>("OtherNonCurrentAssets")
                        .HasColumnType("bigint");

                    b.Property<ulong>("OtherNonCurrentLiabilities")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("PropertyPlantEquipment")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("ReportedCurrency")
                        .HasColumnType("longtext");

                    b.Property<ulong>("RetainedEarnings")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("ShortLongTermDebtTotal")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("ShortTermDebt")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("ShortTermInvestments")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(255)");

                    b.Property<ulong>("TotalAssets")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("TotalCurrentAssets")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("TotalCurrentLiabilities")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("TotalLiabilities")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("TotalNonCurrentAssets")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("TotalNonCurrentLiabilities")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("TotalShareholderEquity")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("TreasuryStock")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("BalanceSheetSymbol");

                    b.HasIndex("Symbol");

                    b.ToTable("BalanceSheetReport");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.CashFlow", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("LastApiRefresh")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LastLocalRefresh")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Symbol");

                    b.ToTable("CashFlows");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.CashFlowReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("CapitalExpenditures")
                        .HasColumnType("bigint");

                    b.Property<string>("CashFlowSymbol")
                        .HasColumnType("varchar(255)");

                    b.Property<long>("CashflowFromFinancing")
                        .HasColumnType("bigint");

                    b.Property<long>("CashflowFromInvestment")
                        .HasColumnType("bigint");

                    b.Property<long>("ChangeInCashAndCashEquivalents")
                        .HasColumnType("bigint");

                    b.Property<long>("ChangeInExchangeRate")
                        .HasColumnType("bigint");

                    b.Property<long>("ChangeInInventory")
                        .HasColumnType("bigint");

                    b.Property<long>("ChangeInOperatingAssets")
                        .HasColumnType("bigint");

                    b.Property<long>("ChangeInOperatingLiabilities")
                        .HasColumnType("bigint");

                    b.Property<long>("ChangeInReceivables")
                        .HasColumnType("bigint");

                    b.Property<long>("DepreciationDepletionAndAmortization")
                        .HasColumnType("bigint");

                    b.Property<long>("DividendPayout")
                        .HasColumnType("bigint");

                    b.Property<long>("DividendPayoutCommonStock")
                        .HasColumnType("bigint");

                    b.Property<long>("DividendPayoutPreferredStock")
                        .HasColumnType("bigint");

                    b.Property<string>("FiscalDateEnding")
                        .HasColumnType("longtext");

                    b.Property<long>("NetIncome")
                        .HasColumnType("bigint");

                    b.Property<long>("OperatingCashFlow")
                        .HasColumnType("bigint");

                    b.Property<long>("PaymentsForOperatingActivities")
                        .HasColumnType("bigint");

                    b.Property<long>("PaymentsForRepurchaseOfCommonStock")
                        .HasColumnType("bigint");

                    b.Property<long>("PaymentsForRepurchaseOfEquity")
                        .HasColumnType("bigint");

                    b.Property<long>("PaymentsForRepurchaseOfPreferredStock")
                        .HasColumnType("bigint");

                    b.Property<long>("ProceedsFromIssuanceOfCommonStock")
                        .HasColumnType("bigint");

                    b.Property<long>("ProceedsFromIssuanceOfLongTermDebtAndCapitalSecuritiesNet")
                        .HasColumnType("bigint");

                    b.Property<long>("ProceedsFromIssuanceOfPreferredStock")
                        .HasColumnType("bigint");

                    b.Property<long>("ProceedsFromOperatingActivities")
                        .HasColumnType("bigint");

                    b.Property<long>("ProceedsFromRepaymentsOfShortTermDebt")
                        .HasColumnType("bigint");

                    b.Property<long>("ProceedsFromRepurchaseOfEquity")
                        .HasColumnType("bigint");

                    b.Property<long>("ProceedsFromSaleOfTreasuryStock")
                        .HasColumnType("bigint");

                    b.Property<long>("ProfitLoss")
                        .HasColumnType("bigint");

                    b.Property<string>("ReportedCurrency")
                        .HasColumnType("longtext");

                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("CashFlowSymbol");

                    b.HasIndex("Symbol");

                    b.ToTable("CashFlowReport");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.CompanyOverview", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("AnalystTargetPrice")
                        .HasColumnType("longtext");

                    b.Property<string>("AssetType")
                        .HasColumnType("longtext");

                    b.Property<string>("Beta")
                        .HasColumnType("longtext");

                    b.Property<string>("BookValue")
                        .HasColumnType("longtext");

                    b.Property<string>("CIK")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("Currency")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("DilutedEPSTTM")
                        .HasColumnType("longtext");

                    b.Property<string>("DividendDate")
                        .HasColumnType("longtext");

                    b.Property<string>("DividendPerShare")
                        .HasColumnType("longtext");

                    b.Property<string>("DividendYield")
                        .HasColumnType("longtext");

                    b.Property<string>("EBITDA")
                        .HasColumnType("longtext");

                    b.Property<string>("EPS")
                        .HasColumnType("longtext");

                    b.Property<string>("EVToEBITDA")
                        .HasColumnType("longtext");

                    b.Property<string>("EVToRevenue")
                        .HasColumnType("longtext");

                    b.Property<string>("ExDividendDate")
                        .HasColumnType("longtext");

                    b.Property<string>("Exchange")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FiscalYearEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ForwardPE")
                        .HasColumnType("longtext");

                    b.Property<string>("GrossProfitTTM")
                        .HasColumnType("longtext");

                    b.Property<string>("Industry")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastApiRefresh")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LastLocalRefresh")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LatestQuarter")
                        .HasColumnType("longtext");

                    b.Property<string>("MarketCapitalization")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("OperatingMarginTTM")
                        .HasColumnType("longtext");

                    b.Property<string>("PEGRatio")
                        .HasColumnType("longtext");

                    b.Property<string>("PERatio")
                        .HasColumnType("longtext");

                    b.Property<string>("PriceToBookRatio")
                        .HasColumnType("longtext");

                    b.Property<string>("PriceToSalesRatioTTM")
                        .HasColumnType("longtext");

                    b.Property<string>("ProfitMargin")
                        .HasColumnType("longtext");

                    b.Property<string>("QuarterlyEarningsGrowthYOY")
                        .HasColumnType("longtext");

                    b.Property<string>("QuarterlyRevenueGrowthYOY")
                        .HasColumnType("longtext");

                    b.Property<string>("ReturnOnAssetsTTM")
                        .HasColumnType("longtext");

                    b.Property<string>("ReturnOnEquityTTM")
                        .HasColumnType("longtext");

                    b.Property<string>("RevenuePerShareTTM")
                        .HasColumnType("longtext");

                    b.Property<string>("RevenueTTM")
                        .HasColumnType("longtext");

                    b.Property<string>("Sector")
                        .HasColumnType("longtext");

                    b.Property<string>("SharesOutstanding")
                        .HasColumnType("longtext");

                    b.Property<string>("TrailingPE")
                        .HasColumnType("longtext");

                    b.Property<string>("_200DayMovingAverage")
                        .HasColumnType("longtext");

                    b.Property<string>("_50DayMovingAverage")
                        .HasColumnType("longtext");

                    b.Property<string>("_52WeekHigh")
                        .HasColumnType("longtext");

                    b.Property<string>("_52WeekLow")
                        .HasColumnType("longtext");

                    b.HasKey("Symbol");

                    b.ToTable("CompanyOverviews");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.Earnings", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("LastApiRefresh")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LastLocalRefresh")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Symbol");

                    b.ToTable("Earnings");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.IncomeStatement", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("LastApiRefresh")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LastLocalRefresh")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Symbol");

                    b.ToTable("IncomeStatements");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.IncomeStatementReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("ComprehensiveIncomeNetOfTax")
                        .HasColumnType("bigint");

                    b.Property<long>("CostOfRevenue")
                        .HasColumnType("bigint");

                    b.Property<long>("CostofGoodsAndServicesSold")
                        .HasColumnType("bigint");

                    b.Property<long>("Depreciation")
                        .HasColumnType("bigint");

                    b.Property<long>("DepreciationAndAmortization")
                        .HasColumnType("bigint");

                    b.Property<long>("Ebit")
                        .HasColumnType("bigint");

                    b.Property<long>("Ebitda")
                        .HasColumnType("bigint");

                    b.Property<string>("FiscalDateEnding")
                        .HasColumnType("longtext");

                    b.Property<long>("GrossProfit")
                        .HasColumnType("bigint");

                    b.Property<long>("IncomeBeforeTax")
                        .HasColumnType("bigint");

                    b.Property<string>("IncomeStatementSymbol")
                        .HasColumnType("varchar(255)");

                    b.Property<long>("IncomeTaxExpense")
                        .HasColumnType("bigint");

                    b.Property<long>("InterestAndDebtExpense")
                        .HasColumnType("bigint");

                    b.Property<long>("InterestExpense")
                        .HasColumnType("bigint");

                    b.Property<long>("InterestIncome")
                        .HasColumnType("bigint");

                    b.Property<long>("InvestmentIncomeNet")
                        .HasColumnType("bigint");

                    b.Property<long>("NetIncome")
                        .HasColumnType("bigint");

                    b.Property<long>("NetIncomeFromContinuingOperations")
                        .HasColumnType("bigint");

                    b.Property<long>("NetInterestIncome")
                        .HasColumnType("bigint");

                    b.Property<long>("NonInterestIncome")
                        .HasColumnType("bigint");

                    b.Property<long>("OperatingExpenses")
                        .HasColumnType("bigint");

                    b.Property<long>("OperatingIncome")
                        .HasColumnType("bigint");

                    b.Property<long>("OtherNonOperatingIncome")
                        .HasColumnType("bigint");

                    b.Property<string>("ReportedCurrency")
                        .HasColumnType("longtext");

                    b.Property<long>("ResearchAndDevelopment")
                        .HasColumnType("bigint");

                    b.Property<long>("SellingGeneralAndAdministrative")
                        .HasColumnType("bigint");

                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(255)");

                    b.Property<long>("TotalRevenue")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IncomeStatementSymbol");

                    b.HasIndex("Symbol");

                    b.ToTable("IncomeStatementReport");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.ListingRow", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AssetType")
                        .HasColumnType("longtext");

                    b.Property<string>("DelistingDate")
                        .HasColumnType("longtext");

                    b.Property<string>("Exchange")
                        .HasColumnType("longtext");

                    b.Property<string>("IpoDate")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastApiRefresh")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LastLocalRefresh")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Symbol");

                    b.ToTable("Listing");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.QuarterlyEarning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("EstimatedEPS")
                        .HasColumnType("double");

                    b.Property<DateTime>("FiscalDateEnding")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ReportedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("ReportedEPS")
                        .HasColumnType("double");

                    b.Property<double>("Surprise")
                        .HasColumnType("double");

                    b.Property<double>("SurprisePercentage")
                        .HasColumnType("double");

                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Symbol");

                    b.ToTable("QuarterlyEarning");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.AnnualEarning", b =>
                {
                    b.HasOne("SaluteStocksAPI.Models.FundamentalData.Earnings", null)
                        .WithMany("AnnualEarnings")
                        .HasForeignKey("Symbol");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.BalanceSheetReport", b =>
                {
                    b.HasOne("SaluteStocksAPI.Models.FundamentalData.BalanceSheet", null)
                        .WithMany("AnnualReports")
                        .HasForeignKey("BalanceSheetSymbol");

                    b.HasOne("SaluteStocksAPI.Models.FundamentalData.BalanceSheet", null)
                        .WithMany("QuarterlyReports")
                        .HasForeignKey("Symbol");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.CashFlowReport", b =>
                {
                    b.HasOne("SaluteStocksAPI.Models.FundamentalData.CashFlow", null)
                        .WithMany("AnnualReports")
                        .HasForeignKey("CashFlowSymbol");

                    b.HasOne("SaluteStocksAPI.Models.FundamentalData.CashFlow", null)
                        .WithMany("QuarterlyReports")
                        .HasForeignKey("Symbol");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.IncomeStatementReport", b =>
                {
                    b.HasOne("SaluteStocksAPI.Models.FundamentalData.IncomeStatement", null)
                        .WithMany("AnnualReports")
                        .HasForeignKey("IncomeStatementSymbol");

                    b.HasOne("SaluteStocksAPI.Models.FundamentalData.IncomeStatement", null)
                        .WithMany("QuarterlyReports")
                        .HasForeignKey("Symbol");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.QuarterlyEarning", b =>
                {
                    b.HasOne("SaluteStocksAPI.Models.FundamentalData.Earnings", null)
                        .WithMany("QuarterlyEarnings")
                        .HasForeignKey("Symbol");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.BalanceSheet", b =>
                {
                    b.Navigation("AnnualReports");

                    b.Navigation("QuarterlyReports");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.CashFlow", b =>
                {
                    b.Navigation("AnnualReports");

                    b.Navigation("QuarterlyReports");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.Earnings", b =>
                {
                    b.Navigation("AnnualEarnings");

                    b.Navigation("QuarterlyEarnings");
                });

            modelBuilder.Entity("SaluteStocksAPI.Models.FundamentalData.IncomeStatement", b =>
                {
                    b.Navigation("AnnualReports");

                    b.Navigation("QuarterlyReports");
                });
#pragma warning restore 612, 618
        }
    }
}
