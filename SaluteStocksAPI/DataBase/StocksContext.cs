using Microsoft.EntityFrameworkCore;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.DataBase;

public class StocksContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<BalanceSheet> BalanceSheets;
    public DbSet<CashFlow> CashFlows;
    public DbSet<CompanyOverview> CompanyOverviews;
    public DbSet<Earnings> Earnings;
    public DbSet<IncomeStatement> IncomeStatements;
}