using Cross.BLL;
using Cross.DbFactory;
using Cross.DTO;
using Xunit;
using Microsoft.Data.Entity;
using Cross.Framework.Tools;
using Microsoft.AspNet.Identity.EntityFramework;
namespace Cross.UnitTest
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Account
    {
        [Fact]
        public void AddUser()
        {
            var db = new CrossContext();
            db.Users.Add(new IdentityUser<int>
            {
                NormalizedUserName="duanyumei",
                NormalizedEmail="403033546@qq.com",
                PasswordHash=EncryptTool.Encrypt("123456")
            });
            db.SaveChanges();
        }
    }
}
