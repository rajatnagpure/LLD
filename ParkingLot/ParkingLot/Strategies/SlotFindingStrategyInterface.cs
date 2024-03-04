using ParkingLot.Models;

namespace ParkingLot.Strategies
{
    public interface SlotFindingStrategyInterface
    {
        int EmptySlot(Floor floor, VehicleTypeEnum vehicleType);
    }
}

