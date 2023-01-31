using ASPNETMVCCRUD.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCCRUD.Data
{
	public class MVCDemoDbContext : DbContext
	{
        //pass the options back to the base class (constructor)
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MVCDemoDbContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
		}

		public DbSet<Vehicle> VehicleMake { get; set; }
        public DbSet<VehicleModelExample> VehicleModelExamples { get; set; }
    }
}
