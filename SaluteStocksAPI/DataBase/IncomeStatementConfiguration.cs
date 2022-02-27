using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.DataBase;

public class IncomeStatementConfiguration : BaseEntityConfigurations<IncomeStatement>
{
    public override void Configure(EntityTypeBuilder<IncomeStatement> modelBuilder)
    {
        base.Configure(modelBuilder);
        modelBuilder.ToTable("income_statement");
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