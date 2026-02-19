using aqua_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace aqua_api.Data.Configurations
{
    public class GoodsReceiptConfiguration : BaseEntityConfiguration<GoodsReceipt>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<GoodsReceipt> builder)
        {
            builder.ToTable("RII_GoodsReceipt");
            builder.Property(x => x.ReceiptNo).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ReceiptDate).HasPrecision(3).IsRequired();
            builder.Property(x => x.Status).HasConversion<byte>().IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);

            builder.HasOne(x => x.Project)
                .WithMany(x => x.GoodsReceipts)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.ReceiptNo)
                .IsUnique()
                .HasFilter("[IsDeleted] = 0")
                .HasDatabaseName("UX_RII_GoodsReceipt_ReceiptNo_Active");

            builder.HasCheckConstraint("CK_RII_GoodsReceipt_Status", "[Status] IN (0,1,2)");
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
