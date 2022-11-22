using Entities.Entity.Abstract;

namespace Entities.Entity.Concrete
{
    public class Users : BaseEntity
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
