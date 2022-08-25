using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.DataAccess.Interfaces
{
    public interface IBusDal : IGenericDal<Bus>
    {
        Task<List<Bus>> GetBusesByColorAsync(string color);
    }
}
