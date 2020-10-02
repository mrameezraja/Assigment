using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Assignment.Configuration;
using Assignment.Web;

namespace Assignment.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AssignmentDbContextFactory : IDesignTimeDbContextFactory<AssignmentDbContext>
    {
        public AssignmentDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AssignmentDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AssignmentDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AssignmentConsts.ConnectionStringName));

            return new AssignmentDbContext(builder.Options);
        }
    }
}
