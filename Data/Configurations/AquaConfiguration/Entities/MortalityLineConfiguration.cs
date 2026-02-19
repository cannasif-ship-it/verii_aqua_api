using aqua_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aqua_api.Data.Configurations
{
    public class MortalityLineConfiguration : BaseEntityConfiguration<MortalityLine>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<MortalityLine> builder)
        {
            builder.ToTable("RII_MortalityLine");

            builder.HasOne(x => x.Mortality)
                .WithMany(x => x.Lines)
                .HasForeignKey(x => x.MortalityId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.FishBatch)
                .WithMany(x => x.MortalityLines)
                .HasForeignKey(x => x.FishBatchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ProjectCage)
                .WithMany()
                .HasForeignKey(x => x.ProjectCageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasCheckConstraint("CK_RII_MortalityLine_DeadCount", "[DeadCount] > 0");
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
