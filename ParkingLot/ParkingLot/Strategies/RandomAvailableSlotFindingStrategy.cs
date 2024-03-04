using System;
using ParkingLot.Models;

namespace ParkingLot.Strategies
{
    public class RandomAvailableSlotFindingStrategy: SlotFindingStrategyInterface
    {
        public int EmptySlot(Floor floor, VehicleTypeEnum vehicleType)
        {
            return floor.Slots.FindIndex(x => !x.Filled && x.VehicleType == vehicleType);
        }
    }
}

