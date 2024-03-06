using ParkingLot.Strategies;
using ParkingLot.Models;

namespace ParkingLot.Factories
{
    public class SlotFindingStrategyFactory
    {
        public static SlotFindingStrategyInterface getSlotFindingStrategy(SlotFindingStrategyEnum slotFindingStrategy)
        {
            if(slotFindingStrategy == SlotFindingStrategyEnum.FIRST_EMPTY)
            {
                return new FirstAvailableSlotFindingStrategy();
            }else if(slotFindingStrategy == SlotFindingStrategyEnum.RANDOM)
            {
                return new RandomAvailableSlotFindingStrategy();
            }
            return new FirstAvailableSlotFindingStrategy();
        }
    }
}

