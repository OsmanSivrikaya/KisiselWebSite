using Entities.Entity.Concrete;

namespace Core.Manager
{
    public interface IAccessManager
    {
        public Task<Users> Access(string username, string password);
    }
}
