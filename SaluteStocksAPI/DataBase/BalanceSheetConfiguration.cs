using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.DataBase;

public class BalanceSheetConfiguration : BaseEntityConfigurations<BalanceSheet>
{
    public override void Configure(EntityTypeBuilder<BalanceSheet> modelBuilder)
    {
        base.Configure(modelBuilder);
        modelBuilder.ToTable("balance_sheet");
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