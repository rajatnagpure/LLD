using ParkingLot.Models;

namespace ParkingLot.Repositories
{
    public class ParkingLotRepository
    {
        private Dictionary<long, ParkingLot.Models.ParkingLot> ParkingLots = new Dictionary<long, ParkingLot.Models.ParkingLot>();
        public long IdCount = 0;

        public long Save(ParkingLot.Models.ParkingLot parkingLot)
        {
            ParkingLots[IdCount++] = parkingLot;
            return IdCount - 1;
        }

        public Models.ParkingLot? GetParkingLotById(long id)
        {
            if (!ParkingLots.ContainsKey(id)) return null;
            return ParkingLots[id];
        }
    }
}

