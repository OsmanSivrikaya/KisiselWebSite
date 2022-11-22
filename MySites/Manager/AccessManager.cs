//using Core.Manager;
//using Entities.Entity.Concrete;
//using Service.Services.Abstract;
//namespace MySites.Manager
//{
//    public class AccessManager : IAccessManager
//    {
//        public int UserId { get; set; }

//        private readonly IUserNewService _userNewService;
//        public AccessManager(IUserNewService userNewService)
//        {
//            _userNewService = userNewService;
//        }

//        public async Task<UserNew> Access(string username, string password)
//        {
//            var users = await _userNewService.GetAllAsync();
//            var login = users.FirstOrDefault(w => w.Username == username && w.Password == password);

//            if (login != null)
//            {
//                UserId = login.Id;
//                return login;
//            }
//            else
//                return null;
//        }
//    }
//}
