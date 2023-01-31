namespace ASPNETMVCCRUD.Models.Domain
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string VehicleModel { get; set; } = default!;
        public long Cost { get; set; }
        public DateTime Year { get; set; }
        public string CarShop { get; set; } = default!;
        public string Email { get; set; } = default!;
        public VehicleModelExample VehicleModelExample { get; set; } = default!;
    }
}
