using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MisisClientServer.DataBase;

public class BaseEntityConfigurations<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityInfo
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(x => x.LastLocalRefresh).HasDefaultValueSql("GETDATE()");
        builder.Property(x => x.LastApiRefresh);
        builder.Property(x => x.Symbol);
        builder.HasKey(x => x.Symbol);
    }
}