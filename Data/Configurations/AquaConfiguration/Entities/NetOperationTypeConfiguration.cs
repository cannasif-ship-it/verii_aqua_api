using aqua_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aqua_api.Data.Configurations
{
    public class NetOperationTypeConfiguration : BaseEntityConfiguration<NetOperationType>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<NetOperationType> builder)
        {
            builder.ToTable("RII_NetOperationType");
            builder.Property(x => x.Code).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.HasIndex(x => x.Code)
                .IsUnique()
                .HasFilter("[IsDeleted] = 0")
                .HasDatabaseName("UX_RII_NetOperationType_Code_Active");

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
