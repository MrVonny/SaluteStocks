using Microsoft.EntityFrameworkCore;
using MisisClientServer.Models.FundamentalData;

namespace MisisClientServer.DataBase;

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

        modelBuilder.Entity<AnnualEarning>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<BalanceSheetAnnualReport>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<CashFlowAnnualReport>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<CashFlowAnnualReport>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<QuarterlyEarning>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<BalanceSheetQuarterlyReports>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<CashFlowQuarterlyReport>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<IncomeStatementQuarterlyReport>()
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();
    }
    
    public DbSet<BalanceSheet> BalanceSheets { get; set; }
    public DbSet<CashFlow> CashFlows { get; set; }
    public DbSet<CompanyOverview> CompanyOverviews { get; set; }
    public DbSet<Earnings> Earnings { get; set; }
    public DbSet<IncomeStatement> IncomeStatements { get; set; }

    public DbSet<ListingRow> Listing { get; set; }
}