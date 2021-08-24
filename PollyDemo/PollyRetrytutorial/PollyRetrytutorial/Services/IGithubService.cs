using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PollyRetrytutorial.Services
{
   public interface IGithubService
    {
        Task<GithubUser> GetUserByUsernameAsync(string userName);
        Task<List<GithubUser>> GetUsersFromOrgAsync(string orgName);
    }
}
