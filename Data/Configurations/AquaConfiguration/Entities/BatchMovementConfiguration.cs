using aqua_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aqua_api.Data.Configurations
{
    public class BatchMovementConfiguration : BaseEntityConfiguration<BatchMovement>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<BatchMovement> builder)
        {
            builder.ToTable("RII_BatchMovement");
            builder.Property(x => x.MovementDate).HasPrecision(3).IsRequired();
            builder.Property(x => x.MovementType).HasConversion<byte>().IsRequired();
            builder.Property(x => x.SignedBiomassGram).HasPrecision(18, 3);
            builder.Property(x => x.ReferenceTable).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);

            builder.HasOne(x => x.FishBatch)
                .WithMany(x => x.BatchMovements)
                .HasForeignKey(x => x.FishBatchId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ProjectCage)
                .WithMany()
                .HasForeignKey(x => x.ProjectCageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => new { x.FishBatchId, x.MovementDate }).HasDatabaseName("IX_RII_BatchMovement_BatchDate");
            builder.HasCheckConstraint("CK_RII_BatchMovement_MovementType", "[MovementType] IN (0,1,2,3,4,5)");
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
