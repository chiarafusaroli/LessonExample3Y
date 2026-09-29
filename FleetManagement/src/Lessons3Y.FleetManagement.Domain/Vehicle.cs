namespace Lessons3Y.FleetManagement.Domain
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string LicensePlate { get; set; } = string.Empty;
        public double OdometerKm { get; set; }
        public decimal DailyRateAmount { get; set; }
        public string Currency { get; set; } = "EUR";
        public double FuelLevelPercentage { get; set; }

    }
}
