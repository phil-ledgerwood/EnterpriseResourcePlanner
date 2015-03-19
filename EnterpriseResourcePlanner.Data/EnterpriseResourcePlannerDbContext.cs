using System.Data.Entity;
using EnterpriseResourcePlanner.Domain;

namespace EnterpriseResourcePlanner.Data
{
    public class EnterpriseResourcePlannerDbContext : DbContext, IDbContext
    {
        static EnterpriseResourcePlannerDbContext()
        {
            Database.SetInitializer<EnterpriseResourcePlannerDbContext>(null);
        }

        public EnterpriseResourcePlannerDbContext() : base("EnterpriseResourcePlannerDbContext") { }

        public DbSet<User> Users { get; set; }
    }
}
