using EmreUgur.BackedProject.Entities.Concrete;
using EmreUgur.BackedProject.Entities.Token;

namespace EmreUgur.BackedProject.Business.Tools.JWTTool
{
    public interface ITokenService
    {
        AccessToken GenerateToken(AppUser appUser, List<AppRole> roles);
    }
}
