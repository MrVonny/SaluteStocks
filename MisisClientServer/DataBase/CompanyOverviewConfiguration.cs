using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MisisClientServer.Models.FundamentalData;

namespace MisisClientServer.DataBase;

public class CompanyOverviewConfiguration : BaseEntityConfigurations<CompanyOverview>
{
    public override void Configure(EntityTypeBuilder<CompanyOverview> modelBuilder)
    {
        base.Configure(modelBuilder);
    }
}