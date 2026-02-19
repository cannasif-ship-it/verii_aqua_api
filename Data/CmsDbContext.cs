using Microsoft.EntityFrameworkCore;
using crm_api.Models;
using crm_api.Models.UserPermissions;
using depoWebAPI.Models;

namespace crm_api.Data
{
    public class CmsDbContext : DbContext
    {
        public CmsDbContext(DbContextOptions<CmsDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAuthority> UserAuthorities { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockDetail> StockDetails { get; set; }
        public DbSet<StockImage> StockImages { get; set; }
        public DbSet<StockRelation> StockRelations { get; set; }

        public DbSet<SmtpSetting> SmtpSettings { get; set; }

        public DbSet<PermissionDefinition> PermissionDefinitions { get; set; }
        public DbSet<PermissionGroup> PermissionGroups { get; set; }
        public DbSet<PermissionGroupPermission> PermissionGroupPermissions { get; set; }
        public DbSet<UserPermissionGroup> UserPermissionGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                    {
                        property.SetColumnType("decimal(18,6)");
                    }
                }
            }

            // ERP functions are intentionally preserved.
            modelBuilder.Entity<RII_FN_KUR>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("__EFMigrationsHistory_FN_KUR", t => t.ExcludeFromMigrations());
                entity.ToFunction("RII_FN_KUR");
            });

            modelBuilder.Entity<RII_FN_2SHIPPING>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("__EFMigrationsHistory_FN_2SHIPPING", t => t.ExcludeFromMigrations());
                entity.ToFunction("RII_FN_2SHIPPING");
            });

            modelBuilder.Entity<RII_STGROUP>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("__EFMigrationsHistory_STGROUP", t => t.ExcludeFromMigrations());
                entity.ToFunction("RII_STGROUP");
            });

            modelBuilder.Entity<RII_FN_STOK>(entity =>
            {
                entity.HasNoKey();
                entity.ToTable("__EFMigrationsHistory_FN_STOK", t => t.ExcludeFromMigrations());
                entity.ToFunction("RII_FN_STOK");
            });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CmsDbContext).Assembly);
        }
    }
}
