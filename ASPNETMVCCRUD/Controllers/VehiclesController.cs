using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models;
using ASPNETMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCCRUD.Controllers
{
	public class VehiclesController : Controller
	{
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public VehiclesController(MVCDemoDbContext mvcDemoDbContext)
		{
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

		[HttpGet]
		public async Task<IActionResult> Index()
		{
		var vehicles =	await mvcDemoDbContext.VehicleMake.ToListAsync();
		return View(vehicles);

        }


		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		//create a functionality to add a new Vehicle 
		[HttpPost]
		public async Task<IActionResult> Add(AddVehicleViewModel addVehicleRequest)
		{
			var vehicle = new Vehicle()
			{
				Id = Guid.NewGuid(),
				Name = addVehicleRequest.Name,
				Email = addVehicleRequest.Email,
				Cost = addVehicleRequest.Cost,
				CarShop = addVehicleRequest.CarShop,
				Year = addVehicleRequest.Year,
			};

            await mvcDemoDbContext.VehicleMake.AddAsync(vehicle);
            await mvcDemoDbContext.SaveChangesAsync();
			return RedirectToAction("Index");
        }

		[HttpGet]
		public async Task<ActionResult> View(Guid id)
		{
            var vehicle = await mvcDemoDbContext.VehicleMake.FirstOrDefaultAsync(x => x.Id == id);

			if(vehicle == null)
			{
				var viewModel = new UpdateVehicleViewModel()
				{
					Id = vehicle.Id,
					Name = vehicle.Name,
					Email = vehicle.Email,
					Cost = vehicle.Cost,
					CarShop = vehicle.CarShop,
					Year = vehicle.Year,
				};

				return await Task.Run(() => View("View", viewModel));

            }
            return RedirectToAction("Index");
		}

		[HttpPost]
		public async Task<IActionResult> View(UpdateVehicleViewModel model)
		{
			var vehicle = await mvcDemoDbContext.VehicleMake.FindAsync(model.Id);

			if (vehicle != null)
			{
				vehicle.Name = model.Name;
                vehicle.Email = model.Email;
                vehicle.Cost = model.Cost;
                vehicle.Year = model.Year;
                vehicle.CarShop = model.CarShop;

				await mvcDemoDbContext.SaveChangesAsync();

				return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

		[HttpPost]
		public async Task<IActionResult> Delete(UpdateVehicleViewModel model)
		{
			var vehicle = await mvcDemoDbContext.VehicleMake.FindAsync(model.Id);

			if (vehicle != null)
			{
				mvcDemoDbContext.VehicleMake.Remove(vehicle);
				await mvcDemoDbContext.SaveChangesAsync();

				return RedirectToAction("Index");
			}
			//if it is not found then just display action method
            return RedirectToAction("Index");

        }
    }
}
