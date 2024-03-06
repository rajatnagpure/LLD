using ParkingLot.Models;

namespace ParkingLot.Models
{
    public interface SlotFindingStrategyInterface
    {
        int EmptySlot(Floor floor, VehicleTypeEnum vehicleType);
    }
}

