using aqua_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aqua_api.Data.Configurations
{
    public class TransferLineConfiguration : BaseEntityConfiguration<TransferLine>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<TransferLine> builder)
        {
            builder.ToTable("RII_TransferLine");
            builder.Property(x => x.AverageGram).HasPrecision(18, 3);
            builder.Property(x => x.BiomassGram).HasPrecision(18, 3);

            builder.HasOne(x => x.Transfer)
                .WithMany(x => x.Lines)
                .HasForeignKey(x => x.TransferId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.FishBatch)
                .WithMany(x => x.TransferLines)
                .HasForeignKey(x => x.FishBatchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.FromProjectCage)
                .WithMany()
                .HasForeignKey(x => x.FromProjectCageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ToProjectCage)
                .WithMany()
                .HasForeignKey(x => x.ToProjectCageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasCheckConstraint("CK_RII_TransferLine_Positive", "[FishCount] > 0 AND [AverageGram] > 0 AND [BiomassGram] > 0");
            builder.HasCheckConstraint("CK_RII_TransferLine_FromToDiff", "[FromProjectCageId] <> [ToProjectCageId]");
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
