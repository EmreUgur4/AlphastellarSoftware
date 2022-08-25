using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.Business.Interfaces
{
    public interface IBusService : IGenericService<Bus>
    {
        Task<List<Bus>> GetBusesByColorAsync(string color);
    }
}
