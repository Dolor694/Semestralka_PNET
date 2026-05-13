using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Gym.Models.Data
{
    public class GymDbContextFactory : IDesignTimeDbContextFactory<GymDbContext>
    {
        public GymDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GymDbContext>();
            optionsBuilder.UseSqlite("Data Source=gym.db");

            return new GymDbContext(optionsBuilder.Options);
        }
    }
}