using ASPNETMVCCRUD.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCCRUD.Data
{
	public class MVCDemoDbContext : DbContext
	{
        //pass the options back to the base class (constructor)
        public MVCDemoDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Vehicle> VehicleMake { get; set; }
	}
}
