using WholeSaler.Context;
using WholeSaler.Entity;

namespace WholeSaler.Seeder
{
    public class OpeningBalanceSeeder
    {
        private readonly CoreContext _context;

        public OpeningBalanceSeeder(CoreContext context)
        {
            _context = context;
        }

        public void seeder ()
        {
            bool shouldSeedRoles = _context.Database.CanConnect() && !_context.roles.Any();
            if (shouldSeedRoles)
            {
                var rolesList = new List<Role>()
                   {
                        new Role()
                        {
                            RoleName="user"
                        },
                        new Role()
                        {
                            RoleName="manager"
                        }
                    };
                _context.roles.AddRange(rolesList);
                _context.SaveChanges();
            }
        }
    }
}
