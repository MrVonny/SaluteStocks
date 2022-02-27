using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaluteStocksAPI.Models.FundamentalData;

namespace SaluteStocksAPI.DataBase;

public class CompanyOverviewConfiguration : BaseEntityConfigurations<CompanyOverview>
{
    public override void Configure(EntityTypeBuilder<CompanyOverview> modelBuilder)
    {
        base.Configure(modelBuilder);
    }
}