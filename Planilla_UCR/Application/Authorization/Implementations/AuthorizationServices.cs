using System.Threading.Tasks;
using Domain.Authorization.Repositories;

namespace Application.Authorization.Implementations
{
    public class AuthorizationServices : IAuthorizationServices
    {
        private readonly IAuthorizationRepository _authorizationRepository;
        public AuthorizationServices(IAuthorizationRepository authorization) {
            _authorizationRepository = authorization;
        }
        public async Task configureRoles() {
            await _authorizationRepository.configureRoles();
        }
        public async Task assignRole(string email, string role){
            await _authorizationRepository.assignRole(email,role);
        }
        public async Task removeRole(string email, string role){
            await _authorizationRepository.removeRole(email, role);
        }
    }
}
