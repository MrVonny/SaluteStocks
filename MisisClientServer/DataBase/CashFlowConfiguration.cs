using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisisClientServer.Models.FundamentalData;

namespace MisisClientServer.DataBase;

public class CashFlowConfiguration : BaseEntityConfigurations<CashFlow>
{
    public override void Configure(EntityTypeBuilder<CashFlow> modelBuilder)
    {
        base.Configure(modelBuilder);
        modelBuilder.HasMany(x => x.AnnualReports)
            .WithOne(x => x.CashFlow)
            .HasForeignKey(x => x.Symbol);
        modelBuilder.HasMany(x => x.QuarterlyReports)
            .WithOne(x => x.CashFlow)
            .HasForeignKey(x => x.Symbol);
        
        modelBuilder
            .HasOne(x => x.CompanyOverview)
            .WithOne(x => x.CashFlow)
            .HasForeignKey<CashFlow>(x => x.Symbol);
    }
    
}