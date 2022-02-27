using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.DataBase;

public class CompanyOverviewConfiguration : BaseEntityConfigurations<CompanyOverview>
{
    public override void Configure(EntityTypeBuilder<CompanyOverview> modelBuilder)
    {
        base.Configure(modelBuilder);
        modelBuilder.ToTable("company_overview");
        modelBuilder
            .HasOne(x => x.BalanceSheet)
            .WithOne(x => x.CompanyOverview)
            .HasForeignKey<CompanyOverview>(x=>x.Symbol);
        modelBuilder
            .HasOne(x => x.CashFlow)
            .WithOne(x => x.CompanyOverview)
            .HasForeignKey<CompanyOverview>(x=>x.Symbol);
        modelBuilder
            .HasOne(x => x.Earnings)
            .WithOne(x => x.CompanyOverview)
            .HasForeignKey<CompanyOverview>(x=>x.Symbol);
        modelBuilder
            .HasOne(x => x.IncomeStatement)
            .WithOne(x => x.CompanyOverview)
            .HasForeignKey<CompanyOverview>(x=>x.Symbol);
    }
}