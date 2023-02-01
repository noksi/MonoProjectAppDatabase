using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models;
using ASPNETMVCCRUD.Models.Domain;
using ASPNETMVCCRUD.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ASPNETMVCCRUD.Controllers
{
	public class VehiclesController : Controller
	{
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        // Assign the object in the constructor for dependency injection
        public VehiclesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Private member variables...
        private IUserRepository userRepository;
        #endregion

//        #region Public Constructor…
//        /// <summary>
//        /// Public Controller to initialize User Repository
//        /// </summary>
//#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
//        public VehiclesController()
//#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
//        {
//            this.userRepository = new UserRepository(new MVCDemoDbContext());
//        }
//        #endregion


        public readonly MVCDemoDbContext mvcDemoDbContext;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public VehiclesController(MVCDemoDbContext mvcDemoDbContext)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
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

			//Mapper.CreateMap<>
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

			var model = _mapper.Map<Profile>(User);
			//return vehicle = AutoMapper.Mapper.Map<List<Profile>, List<VehiclesController>>(vehicle);
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

		[HttpPost] //Delete action method
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
