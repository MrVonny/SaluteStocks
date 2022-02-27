using Microsoft.EntityFrameworkCore;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.DataBase;

public class StocksContext : DbContext
{
    public StocksContext(DbContextOptions<StocksContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BalanceSheetConfiguration());
        modelBuilder.ApplyConfiguration(new CashFlowConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyOverviewConfiguration());
        modelBuilder.ApplyConfiguration(new EarningsConfiguration());
        modelBuilder.ApplyConfiguration(new IncomeStatementConfiguration());
    }

    public DbSet<BalanceSheet> BalanceSheets { get; set; }
    public DbSet<CashFlow> CashFlows { get; set; }
    public DbSet<CompanyOverview> CompanyOverviews { get; set; }
    public DbSet<Earnings> Earnings { get; set; }
    public DbSet<IncomeStatement> IncomeStatements { get; set; }

    public DbSet<ListingRow> Listing { get; set; }
}