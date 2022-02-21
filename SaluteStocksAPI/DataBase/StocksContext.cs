using Microsoft.EntityFrameworkCore;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.DataBase;

public class StocksContext : DbContext
{
    public StocksContext(DbContextOptions<StocksContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BalanceSheet>()
            .HasMany(x => x.AnnualReports)
            .WithOne()
            .HasForeignKey(x => x.Symbol);
        
        modelBuilder.Entity<BalanceSheet>()
            .HasMany(x => x.QuarterlyReports)
            .WithOne()
            .HasForeignKey(x => x.Symbol);
        
        modelBuilder.Entity<CashFlow>()
            .HasMany(x => x.AnnualReports)
            .WithOne()
            .HasForeignKey(x => x.Symbol);
        modelBuilder.Entity<CashFlow>()
            .HasMany(x => x.QuarterlyReports)
            .WithOne()
            .HasForeignKey(x => x.Symbol);

        modelBuilder.Entity<Earnings>()
            .HasMany(x => x.AnnualEarnings)
            .WithOne()
            .HasForeignKey(x => x.Symbol);
        modelBuilder.Entity<Earnings>()
            .HasMany(x => x.QuarterlyEarnings)
            .WithOne()
            .HasForeignKey(x => x.Symbol);

        modelBuilder.Entity<IncomeStatement>()
            .HasMany(x => x.AnnualReports)
            .WithOne()
            .HasForeignKey(x => x.Symbol);
        modelBuilder.Entity<IncomeStatement>()
            .HasMany(x => x.QuarterlyReports)
            .WithOne()
            .HasForeignKey(x => x.Symbol);
    }

    public DbSet<BalanceSheet> BalanceSheets { get; set; }
    public DbSet<CashFlow> CashFlows { get; set; }
    public DbSet<CompanyOverview> CompanyOverviews { get; set; }
    public DbSet<Earnings> Earnings { get; set; }
    public DbSet<IncomeStatement> IncomeStatements { get; set; }

    public DbSet<ListingRow> Listing { get; set; }
}