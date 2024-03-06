using ParkingLot.Models;

namespace ParkingLot.Repositories
{
    public class VehicleRepository
    {
        private Dictionary<long, Vehicle> Vehicles = new Dictionary<long, Vehicle>();
        public long IdCount = 0;

        public long Save(Vehicle vehicle)
        {
            Vehicles[IdCount++] = vehicle;
            return IdCount - 1;
        }

        public Vehicle? GetVehicleById(long id)
        {
            if (!Vehicles.ContainsKey(id)) return null;
            return Vehicles[id];
        }

        public Vehicle? GetVehicleByRegNum(string regNum)
        {
            return Vehicles.Values.FirstOrDefault(x => x.RegNum == regNum);
        }
    }
}

