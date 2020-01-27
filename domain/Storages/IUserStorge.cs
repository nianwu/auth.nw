using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using domain.Models;

namespace domain.Storages
{
    public interface IUserStorage
    {
        User AutoProvisionUser(string provider, string userId, List<Claim> claims);
        User FindByExternalProvider(string provider, string userId);
        Task<User> FindBySubjectIdAsync(string subjectId);
        User FindByUsername(string username);
        bool ValidateCredentials(string username, string password);
    }
}