using aqua_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aqua_api.Data.Configurations
{
    public class FeedingDistributionConfiguration : BaseEntityConfiguration<FeedingDistribution>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<FeedingDistribution> builder)
        {
            builder.ToTable("RII_FeedingDistribution");
            builder.Property(x => x.FeedGram).HasPrecision(18, 3);

            builder.HasOne(x => x.FeedingLine)
                .WithMany(x => x.Distributions)
                .HasForeignKey(x => x.FeedingLineId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.FishBatch)
                .WithMany(x => x.FeedingDistributions)
                .HasForeignKey(x => x.FishBatchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ProjectCage)
                .WithMany()
                .HasForeignKey(x => x.ProjectCageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasCheckConstraint("CK_RII_FeedingDistribution_FeedGram", "[FeedGram] > 0");
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
