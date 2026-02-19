using aqua_api.Models;

namespace aqua_api.Models.UserPermissions
{
    public class UserPermissionGroup : BaseEntity
    {
        public long UserId { get; set; }
        public User User { get; set; } = null!;

        public long PermissionGroupId { get; set; }
        public PermissionGroup PermissionGroup { get; set; } = null!;
    }
}
