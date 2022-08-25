using EmreUgur.BackedProject.Business.Interfaces;
using EmreUgur.BackedProject.Business.Tools.JWTTool;
using EmreUgur.BackedProject.DTO.Dtos;
using EmreUgur.BackedProject.WebApi.CustomFilters;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EmreUgur.BackedProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    [ApiKey]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly ITokenService _tokenService;

        public AuthController(IAppUserService appUserService, ITokenService tokenService)
        {
            _appUserService = appUserService;
            _tokenService = tokenService;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserSignInDto appUserSignInDto)
        {
            var appUser = await _appUserService.FindByUserNameAsync(appUserSignInDto.UserName);

            if (appUser == null)
            {
                return BadRequest("UserName or Password is wrong");
            }
            else
            {
                if (await _appUserService.CheckPasswordAsync(appUserSignInDto))
                {
                    var roles = await _appUserService.GetRolesByUserNameAsync(appUserSignInDto.UserName);

                    return Created("", _tokenService.GenerateToken(appUser, roles));
                }
                else
                {
                    return BadRequest("UserName or Password is wrong");
                }
            }
        }

    }
}
