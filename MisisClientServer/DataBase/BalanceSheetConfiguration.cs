using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisisClientServer.Models.FundamentalData;

namespace MisisClientServer.DataBase;

public class BalanceSheetConfiguration : BaseEntityConfigurations<BalanceSheet>
{
    public override void Configure(EntityTypeBuilder<BalanceSheet> modelBuilder)
    {
        base.Configure(modelBuilder);
        modelBuilder.HasMany(x => x.AnnualReports)
            .WithOne(x => x.BalanceSheet)
            .HasForeignKey(x => x.Symbol);
        modelBuilder.HasMany(x => x.QuarterlyReports)
            .WithOne(x => x.BalanceSheet)
            .HasForeignKey(x => x.Symbol);
        
        modelBuilder
            .HasOne(x => x.CompanyOverview)
            .WithOne(x => x.BalanceSheet)
            .HasForeignKey<BalanceSheet>(x => x.Symbol);
    }
}