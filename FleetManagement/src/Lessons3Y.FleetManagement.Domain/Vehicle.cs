namespace Lessons3Y.FleetManagement.Domain
{
    /// <summary>
    /// Represents a vehicle in the fleet management system, including its properties and behaviors.
    /// </summary>
    public class Vehicle
    {
        public Guid Id { get; }
        public string LicensePlate { get; private set; }
        public double OdometerKm { get; private set; }
        public decimal DailyRateAmount { get; private set; }
        public string Currency { get; private set; }
        public double FuelLevelPercentage { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Vehicle class with the specified parameters.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="licensePlate"></param>
        /// <param name="initialKm"></param>
        /// <param name="dailyRateAmount"></param>
        /// <param name="currency"></param>
        /// <exception cref="ArgumentException"></exception>
        public Vehicle(Guid id, string licensePlate, double initialKm, decimal dailyRateAmount, string currency = "EUR")
        {
            if (id == Guid.Empty)
                throw new ArgumentException("L'ID del veicolo non può essere vuoto.", nameof(id));

            // Validazione stringa targa fatta "a mano" nell'entità
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new ArgumentException("La targa è obbligatoria.", nameof(licensePlate));

            string cleanPlate = licensePlate.Trim().ToUpperInvariant();
            if (cleanPlate.Length < 6 || cleanPlate.Length > 8)
                throw new ArgumentException("Formato targa non valido.", nameof(licensePlate));

            if (initialKm < 0)
                throw new ArgumentException("Il chilometraggio non può essere negativo.", nameof(initialKm));

            if (dailyRateAmount < 0)
                throw new ArgumentException("La tariffa non può essere negativa.", nameof(dailyRateAmount));

            if (string.IsNullOrWhiteSpace(currency))
                throw new ArgumentException("La valuta è obbligatoria.", nameof(currency));

            Id = id;
            LicensePlate = cleanPlate;
            OdometerKm = initialKm;
            DailyRateAmount = dailyRateAmount;
            Currency = currency.Trim().ToUpperInvariant();
            FuelLevelPercentage = 100.0;
        }

        /// <summary>
        /// Records a trip for the vehicle, updating the odometer and fuel level.
        /// </summary>
        /// <param name="kilometersDriven"></param>
        /// <param name="fuelConsumedPercentage"></param>
        /// <exception cref="ArgumentException"></exception>
        public void RecordTrip(double kilometersDriven, double fuelConsumedPercentage)
        {
            if (kilometersDriven <= 0)
                throw new ArgumentException("I chilometri percorsi devono essere maggiori di zero.", nameof(kilometersDriven));

            if (fuelConsumedPercentage < 0 || fuelConsumedPercentage > 100)
                throw new ArgumentException("Il carburante consumato deve essere tra 0 e 100.", nameof(fuelConsumedPercentage));

            OdometerKm += kilometersDriven;
            FuelLevelPercentage = Math.Max(0.0, FuelLevelPercentage - fuelConsumedPercentage);
        }

        /// <summary>
        /// Refuels the vehicle by a specified percentage, ensuring the fuel level does not exceed 100%.
        /// </summary>
        /// <param name="percentageAdded"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Refuel(double percentageAdded)
        {
            if (percentageAdded <= 0)
                throw new ArgumentException("La percentuale da aggiungere deve essere maggiore di zero.", nameof(percentageAdded));

            FuelLevelPercentage = Math.Min(100.0, FuelLevelPercentage + percentageAdded);
        }

    }
}
