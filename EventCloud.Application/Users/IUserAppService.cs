using System.Threading.Tasks;
using Abp.Application.Services;
using EventCloud.Users.Dto;
using System.Web.Http;
using System.Collections.Generic;

namespace EventCloud.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);

        [HttpGet]
        IEnumerable<UsersOutput> GetUsers();
        Task<UsersOutput> GetUser(long id);
    }
}