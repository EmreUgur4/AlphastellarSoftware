using EmreUgur.BackedProject.Entities.Interfaces;

namespace EmreUgur.BackedProject.Entities.Concrete
{
    public class AppRole : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
