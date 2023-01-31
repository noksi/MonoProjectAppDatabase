namespace ASPNETMVCCRUD.Models
{
    public class AddVehicleViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string VehicleModel { get; set; } = string.Empty;
        public long Cost { get; set; }
        public DateTime Year { get; set; }
        public string CarShop { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
