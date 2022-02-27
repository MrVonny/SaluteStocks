using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.DataBase;

public class CashFlowConfiguration : BaseEntityConfigurations<CashFlow>
{
    public override void Configure(EntityTypeBuilder<CashFlow> modelBuilder)
    {
        base.Configure(modelBuilder);
        modelBuilder.ToTable("cash_flow");
        modelBuilder
            .HasMany(x => x.AnnualReports)
            .WithOne()
            .HasForeignKey(x => x.Symbol);
        modelBuilder
            .HasMany(x => x.QuarterlyReports)
            .WithOne()
            .HasForeignKey(x => x.Symbol);
    }
}