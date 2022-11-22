using Entities.Entity.Abstract;

namespace Entities.Entity.Concrete
{
    public class RolDto : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
