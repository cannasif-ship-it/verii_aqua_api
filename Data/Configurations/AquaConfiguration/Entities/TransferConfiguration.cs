using aqua_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aqua_api.Data.Configurations
{
    public class TransferConfiguration : BaseEntityConfiguration<Transfer>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Transfer> builder)
        {
            builder.ToTable("RII_Transfer");
            builder.Property(x => x.TransferNo).HasMaxLength(50).IsRequired();
            builder.Property(x => x.TransferDate).HasPrecision(3).IsRequired();
            builder.Property(x => x.Status).HasConversion<byte>().IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);

            builder.HasOne(x => x.Project)
                .WithMany(x => x.Transfers)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.TransferNo)
                .IsUnique()
                .HasFilter("[IsDeleted] = 0")
                .HasDatabaseName("UX_RII_Transfer_TransferNo_Active");

            builder.HasCheckConstraint("CK_RII_Transfer_Status", "[Status] IN (0,1,2)");
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
