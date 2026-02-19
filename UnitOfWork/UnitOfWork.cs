using aqua_api.Data;
using aqua_api.Models;
using aqua_api.Models.UserPermissions;
using aqua_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Concurrent;

namespace aqua_api.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AquaDbContext _context;
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

        public EfUnitOfWork(AquaDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _repositories = new ConcurrentDictionary<Type, object>();
        }

        public AquaDbContext Db => _context;

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

        public Task<int> SaveChanges() => _context.SaveChangesAsync();

        public async Task BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }

            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction is in progress.");
            }

            try
            {
                await _transaction.CommitAsync();
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task Rollback()
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

        public Task<int> SaveChangesAsync() => SaveChanges();
        public Task BeginTransactionAsync() => BeginTransaction();
        public Task CommitTransactionAsync() => Commit();
        public Task RollbackTransactionAsync() => Rollback();

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

    public class UnitOfWork : EfUnitOfWork
    {
        public UnitOfWork(AquaDbContext context, IHttpContextAccessor httpContextAccessor)
            : base(context, httpContextAccessor)
        {
        }
    }
}
