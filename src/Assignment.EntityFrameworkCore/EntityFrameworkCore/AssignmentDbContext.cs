using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Assignment.Authorization.Roles;
using Assignment.Authorization.Users;
using Assignment.MultiTenancy;
using Assignment.Cows;
using Assignment.Sensors;

namespace Assignment.EntityFrameworkCore
{
    public class AssignmentDbContext : AbpZeroDbContext<Tenant, Role, User, AssignmentDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Cow> Cows { get; set; }
        public virtual DbSet<Sensor> Sensors { get; set; }

        public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options)
            : base(options)
        {
        }
    }
}
