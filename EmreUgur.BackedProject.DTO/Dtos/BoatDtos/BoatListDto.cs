using EmreUgur.BackedProject.DTO.Interfaces;

namespace EmreUgur.BackedProject.DTO.Dtos
{
    public class BoatListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }

        public int? VehicleId { get; set; }
        public VehicleListDto Vehicle { get; set; }
    }
}
