using Core.Repository.Abstract;
using Entities.Entity.Concrete;
using Service.Services.Abstract;

namespace Service.Services.Concrete
{
    public class UsersService : GenericService<Users>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UsersService(IGenericRepository<Users> repository, IUserRepository userRepository) : base(repository)
        {
            _userRepository = userRepository;
        }
    }
}
