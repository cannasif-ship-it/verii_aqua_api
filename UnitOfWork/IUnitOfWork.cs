using aqua_api.Data;
using aqua_api.Models;
using aqua_api.Models.UserPermissions;
using aqua_api.Repositories;

namespace aqua_api.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        AquaDbContext Db { get; }

        IGenericRepository<User> Users { get; }
        IGenericRepository<UserAuthority> UserAuthorities { get; }
        IGenericRepository<UserDetail> UserDetails { get; }
        IGenericRepository<UserSession> UserSessions { get; }

        IGenericRepository<Stock> Stocks { get; }
        IGenericRepository<StockDetail> StockDetails { get; }

        IGenericRepository<SmtpSetting> SmtpSettings { get; }

        IGenericRepository<PermissionDefinition> PermissionDefinitions { get; }
        IGenericRepository<PermissionGroup> PermissionGroups { get; }
        IGenericRepository<PermissionGroupPermission> PermissionGroupPermissions { get; }
        IGenericRepository<UserPermissionGroup> UserPermissionGroups { get; }

        Task<int> SaveChanges();
        Task BeginTransaction();
        Task Commit();
        Task Rollback();

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        IGenericRepository<T> Repository<T>() where T : BaseEntity;
    }
}
