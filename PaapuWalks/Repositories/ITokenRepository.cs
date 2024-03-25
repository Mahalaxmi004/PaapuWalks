using Microsoft.AspNetCore.Identity;

namespace PaapuWalks.Repositories
{
    public interface ITokenRepository
    {
       string CreateJWTToken(IdentityUser user, List<string> roles);


    }
}
