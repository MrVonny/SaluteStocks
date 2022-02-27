using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.DataBase;

public class EarningsConfiguration : BaseEntityConfigurations<Earnings>
{
    public override void Configure(EntityTypeBuilder<Earnings> modelBuilder)
    {
        base.Configure(modelBuilder);
        modelBuilder.ToTable("earnings");
        modelBuilder
            .HasMany(x => x.AnnualEarnings)
            .WithOne()
            .HasForeignKey(x => x.Symbol);
        modelBuilder
            .HasMany(x => x.QuarterlyEarnings)
            .WithOne()
            .HasForeignKey(x => x.Symbol);
    }
}