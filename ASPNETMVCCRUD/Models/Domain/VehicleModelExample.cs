namespace ASPNETMVCCRUD.Models.Domain
{
    public class VehicleModelExample
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string MakeId { get; set; } = default!;
        public string Model { get; set; } = default!;
        public List<Vehicle> Vehicles { get; set; } = default!;
    }
}
