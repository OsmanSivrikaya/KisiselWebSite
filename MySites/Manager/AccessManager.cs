using Core.Manager;
using Entities.Entity.Concrete;
using Service.Services.Abstract;
namespace MySites.Manager
{
    public class AccessManager : IAccessManager
    {
        public int UserId { get; set; }

        private readonly IUserService _usersService;
        public AccessManager(IUserService usersService)
        {
            _usersService = usersService;
        }

        public async Task<Users> Access(string username, string password)
        {
            var users = await _usersService.GetAllAsync();
            var login = users.FirstOrDefault(w => w.UserName == username && w.Password == password);

            if (login != null)
            {
                UserId = login.Id;
                return login;
            }
            else
                return null;
        }
    }
}
