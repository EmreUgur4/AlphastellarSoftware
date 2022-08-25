using EmreUgur.BackedProject.Common.Models;
using EmreUgur.BackedProject.Entities.Concrete;
using EmreUgur.BackedProject.Entities.Token;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmreUgur.BackedProject.Business.Tools.JWTTool
{
    public class TokenManager : ITokenService
    {
        private readonly IOptions<TokenInfo> _optionsToken;

        public TokenManager(IOptions<TokenInfo> optionsToken)
        {
            _optionsToken = optionsToken;
        }

        public AccessToken GenerateToken(AppUser appUser, List<AppRole> roles)
        {
            var tokenInfo = _optionsToken.Value;

            SymmetricSecurityKey symmetricSecurityKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenInfo.SecurityKey));

            SigningCredentials signingCredentials =
                new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken =
                new JwtSecurityToken(issuer: tokenInfo.Issuer, audience: tokenInfo.Audience,
                notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(tokenInfo.TokenExpiration)
                , signingCredentials: signingCredentials, claims: GetClaims(appUser, roles));

            AccessToken token = new AccessToken();

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            token.Token = handler.WriteToken(jwtSecurityToken);

            return token;
        }

        private List<Claim> GetClaims(AppUser appUser, List<AppRole> roles)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));

            if (roles?.Count > 0)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));
                }
            }

            return claims;
        }
    }
}
