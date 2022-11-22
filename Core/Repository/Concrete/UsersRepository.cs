using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Microsoft.Extensions.Configuration;

namespace Core.Repository.Concrete
{
    public class UsersRepository : GenericRepository<Users>, IUserRepository
    {
        public UsersRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
