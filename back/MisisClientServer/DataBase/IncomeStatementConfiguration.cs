using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisisClientServer.Models.FundamentalData;

namespace MisisClientServer.DataBase;

public class IncomeStatementConfiguration : BaseEntityConfigurations<IncomeStatement>
{
    public override void Configure(EntityTypeBuilder<IncomeStatement> modelBuilder)
    {
        base.Configure(modelBuilder);
        modelBuilder.HasMany(x => x.AnnualReports)
            .WithOne(x => x.IncomeStatement)
            .HasForeignKey(x => x.Symbol);
        modelBuilder.HasMany(x => x.QuarterlyReports)
            .WithOne(x => x.IncomeStatement)
            .HasForeignKey(x => x.Symbol);
        
        modelBuilder
            .HasOne(x => x.CompanyOverview)
            .WithOne(x => x.IncomeStatement)
            .HasForeignKey<IncomeStatement>(x => x.Symbol);
    }
}