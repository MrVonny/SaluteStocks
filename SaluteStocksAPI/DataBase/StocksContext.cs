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

    public DbSet<BalanceSheet> BalanceSheets { get; set; }
    public DbSet<CashFlow> CashFlows { get; set; }
    public DbSet<CompanyOverview> CompanyOverviews { get; set; }
    public DbSet<Earnings> Earnings { get; set; }
    public DbSet<IncomeStatement> IncomeStatements { get; set; }

    public DbSet<ListingRow> Listing { get; set; }
}