namespace ASPNETMVCCRUD.Models.Domain
{
	public class Vehicle
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public long Cost { get; set; }
		public DateTime Year { get; set; }
        public string CarShop { get; set; }
	}
}
