using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models;
using ASPNETMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCCRUD.Controllers
{
	public class VehiclesController : Controller
	{
        public readonly MVCDemoDbContext mvcDemoDbContext;

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
		//create a functionality to add a new VehicleModel 
		[HttpPost]
		public async Task<IActionResult> Add(AddVehicleViewModel addVehicleRequest)
		{
			var vehicle = new Vehicle()
			{
				Id = Guid.NewGuid(),
				Name = addVehicleRequest.Name,
				VehicleModel = addVehicleRequest.VehicleModel,
				Cost = addVehicleRequest.Cost,
				CarShop = addVehicleRequest.CarShop,
				Year = addVehicleRequest.Year,
                Email = addVehicleRequest.Email,
            };

            await mvcDemoDbContext.VehicleMake.AddAsync(vehicle);
            await mvcDemoDbContext.SaveChangesAsync();
			return RedirectToAction("Index");  //return to Index page
        }

		[HttpGet]
		public async Task<ActionResult> View(Guid id)
		{
            var vehicle = await mvcDemoDbContext.VehicleMake.FirstOrDefaultAsync(x => x.Id == id);

			if (vehicle != null)
			{
                var viewModel = new UpdateVehicleViewModel()
				{
					Id = vehicle.Id,
					Name = vehicle.Name,
					VehicleModel = vehicle.VehicleModel,
					Cost = vehicle.Cost,
					CarShop = vehicle.CarShop,
					Year = vehicle.Year,
                    Email = vehicle.Email,
                };

                return await Task.Run(() => View("View", viewModel)); //run this View as a task

            }
            return RedirectToAction("Index");
		}

		[HttpPost] //post method for View action
		public async Task<IActionResult> View(UpdateVehicleViewModel model)
		{
			var vehicle = await mvcDemoDbContext.VehicleMake.FindAsync(model.Id);

			if (vehicle != null)
			{
				vehicle.Name = model.Name; //not update the original Id property but rest of the value of our vehicle
				vehicle.VehicleModel = model.VehicleModel;
				vehicle.Cost = model.Cost;
                vehicle.Year = model.Year;
                vehicle.CarShop = model.CarShop;
                vehicle.Email = model.Email;

                await mvcDemoDbContext.SaveChangesAsync();

				return RedirectToAction("Index"); //when changes are saved return to Index page
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
