using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.DataAccess.Interfaces
{
    public interface IBoatDal : IGenericDal<Boat>
    {
        Task<List<Boat>> GetBoatsByColorAsync(string color);
    }
}
