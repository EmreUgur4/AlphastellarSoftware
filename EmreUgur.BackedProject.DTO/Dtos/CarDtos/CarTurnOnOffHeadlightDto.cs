using EmreUgur.BackedProject.DTO.Interfaces;

namespace EmreUgur.BackedProject.DTO.Dtos
{
    public class CarTurnOnOffHeadlightDto : IDto
    {
        public int Id { get; set; }
        public bool IsHeadlightOn { get; set; }
    }
}
