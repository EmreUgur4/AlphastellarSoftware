using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Interfaces
{
    public interface IBoatService : IGenericService<Boat>
    {
        Task<List<Boat>> GetBoatsByColorAsync(string color);
    }
}
