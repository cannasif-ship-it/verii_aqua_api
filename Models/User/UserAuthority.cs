using aqua_api.Models;

namespace aqua_api.Models
{
    public class UserAuthority : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
    }
}