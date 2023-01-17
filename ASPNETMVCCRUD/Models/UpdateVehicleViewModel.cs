namespace ASPNETMVCCRUD.Models
{
    public class UpdateVehicleViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Cost { get; set; }
        public DateTime Year { get; set; }
        public string CarShop { get; set; }
    }
}
