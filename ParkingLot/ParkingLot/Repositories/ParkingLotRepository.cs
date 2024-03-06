using ParkingLot.Models;

namespace ParkingLot.Repositories
{
    public class ParkingLotRepository
    {
        private Dictionary<string, ParkingLot.Models.ParkingLot> ParkingLots = new Dictionary<string, ParkingLot.Models.ParkingLot>();
        public int IdCount { private set; get; }
        public void Save(ParkingLot.Models.ParkingLot parkingLot)
        {
            if (ParkingLots.ContainsKey(parkingLot.StringId))
                throw new InvalidOperationException("ParkingLot Id already in use!");
            ParkingLots[parkingLot.StringId] = parkingLot;
        }

        public Models.ParkingLot? GetParkingLotById(string stringId)
        {
            if (!ParkingLots.ContainsKey(stringId)) return null;
            return ParkingLots[stringId];
        }
    }
}

