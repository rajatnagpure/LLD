using ParkingLot.Models;

namespace ParkingLot.Strategies
{
    public class FirstAvailableSlotFindingStrategy: SlotFindingStrategyInterface
    {
        public int EmptySlot(Floor floor, VehicleTypeEnum vehicleType)
        {
            return floor.Slots.FindIndex(x => !x.Filled && x.VehicleType == vehicleType);
        }
    }
}

