using crm_api.Data;
using crm_api.Models;
using crm_api.Models.UserPermissions;
using crm_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Concurrent;

namespace crm_api.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CmsDbContext _context;
        private readonly ConcurrentDictionary<Type, object> _repositories;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IDbContextTransaction? _transaction;
        private bool _disposed;

        private IGenericRepository<User>? _users;
        private IGenericRepository<UserAuthority>? _userAuthorities;
        private IGenericRepository<UserDetail>? _userDetails;
        private IGenericRepository<UserSession>? _userSessions;

        private IGenericRepository<Stock>? _stocks;
        private IGenericRepository<StockDetail>? _stockDetails;

        private IGenericRepository<SmtpSetting>? _smtpSettings;

        private IGenericRepository<PermissionDefinition>? _permissionDefinitions;
        private IGenericRepository<PermissionGroup>? _permissionGroups;
        private IGenericRepository<PermissionGroupPermission>? _permissionGroupPermissions;
        private IGenericRepository<UserPermissionGroup>? _userPermissionGroups;

        public UnitOfWork(CmsDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _repositories = new ConcurrentDictionary<Type, object>();
        }

        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context, _httpContextAccessor);
        public IGenericRepository<UserAuthority> UserAuthorities => _userAuthorities ??= new GenericRepository<UserAuthority>(_context, _httpContextAccessor);
        public IGenericRepository<UserDetail> UserDetails => _userDetails ??= new GenericRepository<UserDetail>(_context, _httpContextAccessor);
        public IGenericRepository<UserSession> UserSessions => _userSessions ??= new GenericRepository<UserSession>(_context, _httpContextAccessor);

        public IGenericRepository<Stock> Stocks => _stocks ??= new GenericRepository<Stock>(_context, _httpContextAccessor);
        public IGenericRepository<StockDetail> StockDetails => _stockDetails ??= new GenericRepository<StockDetail>(_context, _httpContextAccessor);

        public IGenericRepository<SmtpSetting> SmtpSettings => _smtpSettings ??= new GenericRepository<SmtpSetting>(_context, _httpContextAccessor);

        public IGenericRepository<PermissionDefinition> PermissionDefinitions => _permissionDefinitions ??= new GenericRepository<PermissionDefinition>(_context, _httpContextAccessor);
        public IGenericRepository<PermissionGroup> PermissionGroups => _permissionGroups ??= new GenericRepository<PermissionGroup>(_context, _httpContextAccessor);
        public IGenericRepository<PermissionGroupPermission> PermissionGroupPermissions => _permissionGroupPermissions ??= new GenericRepository<PermissionGroupPermission>(_context, _httpContextAccessor);
        public IGenericRepository<UserPermissionGroup> UserPermissionGroups => _userPermissionGroups ??= new GenericRepository<UserPermissionGroup>(_context, _httpContextAccessor);

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            return (IGenericRepository<T>)_repositories.GetOrAdd(typeof(T), _ => new GenericRepository<T>(_context, _httpContextAccessor));
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch
            {
                if (_transaction != null)
                {
                    await RollbackTransactionAsync();
                }
                throw;
            }
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }

            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction is in progress.");
            }

            try
            {
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction == null)
            {
                return;
            }

            try
            {
                await _transaction.RollbackAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _transaction?.Dispose();
                _context.Dispose();
                _disposed = true;
            }
        }
    }
}
