using crm_api.Models;
using crm_api.Models.UserPermissions;
using crm_api.Repositories;

namespace crm_api.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
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

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        IGenericRepository<T> Repository<T>() where T : BaseEntity;
    }
}
