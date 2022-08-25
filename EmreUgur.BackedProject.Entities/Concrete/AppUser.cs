using EmreUgur.BackedProject.Entities.Interfaces;

namespace EmreUgur.BackedProject.Entities.Concrete
{
    public class AppUser : ITable
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
