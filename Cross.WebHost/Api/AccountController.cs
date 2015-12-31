using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Cross.DTO;
using Cross.BLL;
using System.Security.Claims;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cross.WebHost.Api
{
    public class AccountController : Controller
    {
        private UnitOfWork work = new UnitOfWork();

        [Route("/upload")]
        [HttpPost]
        public async void Index()
        {
           var form= await Request.ReadFormAsync();
           
        }

        [HttpPost]
        public async Task<MethodResult> Login(UserLoginDTO userLoginDTO)
        {
              await HttpContext.Authentication.SignInAsync("ApplicationCookie", CreatePrincipal(userLoginDTO.UserName));

            //var result = await SignInManager.PasswordSignInAsync(userLoginDTO.UserName, userLoginDTO.Password, userLoginDTO.RememberMe.Value, lockoutOnFailure: false);
            var ret = new MethodResult
            {
                State = true
            };
            return ret;
            //if (result.Succeeded)
            //{
            //    ret.State = true;
            //    return ret;
            //}
            //ret.State = false;
            //if (result.IsLockedOut)
            //{
            //    ret.Data = "账号已锁定!";
            //    return ret;
            //}
            //else
            //{
            //    ret.Data = "用户名或密码错误!";
            //    return ret;
            //}

        }


        private ClaimsPrincipal CreatePrincipal(string UserName)
        {
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.Name, UserName));
            var principal = new ClaimsPrincipal(identity);
            return principal;
        }
    }

   
}
