//using Core.Manager;
//using Entities.Entity.Concrete;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Service.Services.Abstract;
//using System.Security.Claims;
//namespace MySites.Manager
//{
//    public class ClaimsManager : IClaimsManager
//    {
//        private readonly IRolService _rolService;
//        private readonly IRolDtoService _rolDtoService;
//        public ClaimsManager(IRolService rolService, IRolDtoService rolDtoService)
//        {
//            _rolService = rolService;
//            _rolDtoService = rolDtoService;
//        }

//        public async Task<ClaimsPrincipal> CreateClaim(UserNew webUser)
//        {
//            var roller = await _rolDtoService.GetAllAsync();
//            var rollerWhere = roller.Where(w => w.UserId == webUser.Id);

//            var rollerinIsimleri = await _rolService.GetAllAsync();

//            var claims = new List<Claim>()
//            {
//                new Claim(ClaimTypes.Name, webUser.Username)
//            };

//            foreach (var rol in rollerWhere)
//            {
//                var rolismi = rollerinIsimleri.FirstOrDefault(w => w.Id == rol.RoleId).RolAdi;
//                claims.Add(new Claim(ClaimTypes.Role, rolismi));
//            }

//            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
//            return claimsPrincipal;
//        }
//    }
//}
