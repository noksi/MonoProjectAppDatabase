using ASPNETMVCCRUD.Data;
using ASPNETMVCCRUD.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETMVCCRUD
{
    public class VehicleRepository : Controller
    {
        //public List<Vehicle> GetVehicles()
        //{
        //    MVCDemoDbContext mVCDemoDbContext = new MVCDemoDbContext();
        //    return mVCDemoDbContext.VehicleMake.ToList();
        //}
        public readonly MVCDemoDbContext mvcDemoDbContext;

        public VehicleRepository(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

    }
}
