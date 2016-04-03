using System.Threading.Tasks;
using Abp.Authorization;
using EventCloud.Users.Dto;
using Abp.AutoMapper;
using System.Linq;
using System.Collections.Generic;

namespace EventCloud.Users
{
    /* THIS IS JUST A SAMPLE. */
    public class UserAppService : EventCloudAppServiceBase, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly IPermissionManager _permissionManager;

        public UserAppService(UserManager userManager, IPermissionManager permissionManager)
        {
            _userManager = userManager;
            _permissionManager = permissionManager;
        }
        
        public IEnumerable<UsersOutput> GetUsers()
        {
            var users = _userManager.Users.Select(u => new UsersOutput { Id = u.Id, EmailAddress = u.EmailAddress, Name = u.Name }).ToList();

            //return new UsersOutput { Users = users };
            return users;
        }

        public async Task ProhibitPermission(ProhibitPermissionInput input)
        {
            var user = await _userManager.GetUserByIdAsync(input.UserId);
            var permission = _permissionManager.GetPermission(input.PermissionName);

            await _userManager.ProhibitPermissionAsync(user, permission);
        }

        //Example for primitive method parameters.
        public async Task RemoveFromRole(long userId, string roleName)
        {
            CheckErrors(await _userManager.RemoveFromRoleAsync(userId, roleName));
        }
    }
}