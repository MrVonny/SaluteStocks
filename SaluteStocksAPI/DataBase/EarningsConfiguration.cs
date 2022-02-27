using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.DataBase;

public class EarningsConfiguration : BaseEntityConfigurations<Earnings>
{
    public override void Configure(EntityTypeBuilder<Earnings> modelBuilder)
    {
        base.Configure(modelBuilder);
        modelBuilder.HasMany(x => x.AnnualEarnings)
            .WithOne(x => x.Earnings)
            .HasForeignKey(x => x.Symbol);
        modelBuilder.HasMany(x => x.QuarterlyEarnings)
            .WithOne(x => x.Earnings)
            .HasForeignKey(x => x.Symbol);
        
        modelBuilder
            .HasOne(x => x.CompanyOverview)
            .WithOne(x => x.Earnings)
            .HasForeignKey<Earnings>(x => x.Symbol);
    }
}