using ParkingLot.Factories;
using ParkingLot.Models;
using ParkingLot.Repositories;

namespace ParkingLot.Services
{
    public class ParkingLotService
    {
        private ParkingLotRepository ParkingLotRepository;
        public ParkingLotService(ParkingLotRepository parkingLotRepository)
        {
            ParkingLotRepository = parkingLotRepository;
        }
        public void InitialiseFloor(Floor floor, int numberOfslotsPerFloor, int slotStartingNumber)
        {
            numberOfslotsPerFloor -= 3;
            while (numberOfslotsPerFloor > 0)
            {
                floor.Slots.Add(new Slot(slotStartingNumber++, VehicleTypeEnum.CAR));
                numberOfslotsPerFloor--;
            }
            floor.Slots.Add(new Slot(slotStartingNumber++, VehicleTypeEnum.TRUCK));
            floor.Slots.Add(new Slot(slotStartingNumber++, VehicleTypeEnum.BIKE));
            floor.Slots.Add(new Slot(slotStartingNumber++, VehicleTypeEnum.BIKE));
        }
        public void CreateParkingLot(string stringId, int mxSlots,int mxFloors, SlotFindingStrategyEnum slotFindingStrategyEnum)
        {
            if (mxSlots < 4) throw new InvalidOperationException("Slots per floor cannot be less than 4");
            if (mxFloors < 1) throw new InvalidOperationException("Floors cannot be zero");
            int slotIdCount = 0;
            List<Floor> floors = new List<Floor>();
            Floor floor;
            for (int i = 0; i < mxFloors; i++)
            {
                floor = new Floor(i);
                InitialiseFloor(floor, mxSlots, slotIdCount++);
                floors.Add(floor);
            }
            Models.ParkingLot parkingLot = new Models.ParkingLot(stringId, ParkingLotRepository.IdCount+1,
                mxSlots,
                mxFloors,
                SlotFindingStrategyFactory.getSlotFindingStrategy(slotFindingStrategyEnum), floors);
            ParkingLotRepository.Save(parkingLot);
        }
        public Models.ParkingLot? GetParkingLot(string id)
        {
            return ParkingLotRepository.GetParkingLotById(id);
        }
    }
}

