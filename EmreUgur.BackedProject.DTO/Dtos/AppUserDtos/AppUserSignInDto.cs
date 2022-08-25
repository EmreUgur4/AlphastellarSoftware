using EmreUgur.BackedProject.DTO.Interfaces;

namespace EmreUgur.BackedProject.DTO.Dtos
{
    public class AppUserSignInDto : IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
