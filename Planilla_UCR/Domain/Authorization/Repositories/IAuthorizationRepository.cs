using System.Threading.Tasks;

namespace Domain.Authorization.Repositories
{
    public interface IAuthorizationRepository
    {
        Task configureRoles();
        Task assignRole(string email, string role);
        Task removeRole(string email, string role);
    }
}
