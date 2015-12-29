using Cross.DbFactory;
using Cross.DTO;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;

namespace Cross.BLL
{
    public class AccountBLL
    {
        private readonly CrossContext _db;

        internal AccountBLL(CrossContext db)
        {
            _db = db;
        }

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="userDto">账号注册信息</param>
        /// <returns></returns>
        public MethodResult RegisterAccount(RegisterDTO userDto)
        {
            var userStore = new UserStore<IdentityUser<int>, IdentityRole<int>, CrossContext, int>(_db);
            var user = new IdentityUser<int>();
            user.UserName = userDto.UserName;
            user.PasswordHash = userDto.Password;
            var result = new MethodResult();
            try
            {
                result.State = userStore.CreateAsync(user).Result.Succeeded;
            }
            catch (Exception ex)
            {
                result.State = false;
                result.Data = ex;
            }
            return result;
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="name">角色名称</param>
        /// <param name="normalizedName">角色普通称谓</param>
        /// <returns></returns>
        public bool CreateRole(string name, string normalizedName)
        {
            var role = new IdentityRole<int>()
            {
                Name = name,
                NormalizedName = normalizedName
            };
            var roleStore = new RoleStore<IdentityRole<int>, CrossContext, int>(_db);
            return roleStore.CreateAsync(role).Result.Succeeded;
        }
    }
}
