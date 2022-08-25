using EmreUgur.BackedProject.DTO.Interfaces;

namespace EmreUgur.BackedProject.DTO.Dtos
{
    public class VehicleListDto : IDto
    {
        public int Id { get; set; }

        public int ColorId { get; set; }
        public ColorListDto Color { get; set; }
    }
}
