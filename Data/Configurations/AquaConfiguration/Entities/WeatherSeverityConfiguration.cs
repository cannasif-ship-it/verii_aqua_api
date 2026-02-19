using aqua_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aqua_api.Data.Configurations
{
    public class WeatherSeverityConfiguration : BaseEntityConfiguration<WeatherSeverity>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<WeatherSeverity> builder)
        {
            builder.ToTable("RII_WeatherSeverity");
            builder.Property(x => x.Code).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.HasIndex(x => x.Code)
                .IsUnique()
                .HasFilter("[IsDeleted] = 0")
                .HasDatabaseName("UX_RII_WeatherSeverity_Code_Active");

            builder.HasCheckConstraint("CK_RII_WeatherSeverity_Score", "[Score] >= 0");
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
