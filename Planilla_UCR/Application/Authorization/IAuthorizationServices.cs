using System.Threading.Tasks;

namespace Application.Authorization
{
    public interface IAuthorizationServices
    {
        Task configureRoles();
        Task assignRole(string email, string role);
        Task removeRole(string email, string role);
    }
}
