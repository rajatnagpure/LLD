namespace ParkingLot.Models
{
    public class ParkingLot: BaseModel
    {
        public int MaxFloors { private set; get; }
        public int MaxSlots { private set; get; }
        public List<Floor> Floors { private set; get; }
        public SlotFindingStrategyInterface SlotFindingStrategy { private set; get; }
        public ParkingLot(long id, int mxSlots, int mxFloors, SlotFindingStrategyInterface slotFindingStrategy, List<Floor> floors): base(id)
        {
            MaxFloors = mxFloors;
            MaxSlots = mxSlots;
            Floors = floors;
            SlotFindingStrategy = slotFindingStrategy;
        }

        public int GetEmptySlotByType(VehicleTypeEnum vehicleType)
        {
            int count = 0;
            foreach(var floor in Floors)
            {
                count += floor.GetFreeSlotByType(vehicleType);
            }
            return count;
        }
        public Dictionary<VehicleTypeEnum, int> GetFreeCountSlots()
        {
            Dictionary<VehicleTypeEnum, int> countDict = new Dictionary<VehicleTypeEnum, int>();
            foreach(VehicleTypeEnum type in Enum.GetValues(typeof(VehicleTypeEnum)))
            {
                countDict[type] = 0;
            }
            foreach (var floor in Floors)
            {
                Dictionary<VehicleTypeEnum, int> dict = floor.GetAllEmptySlotCount();
                foreach(VehicleTypeEnum type in Enum.GetValues(typeof(VehicleTypeEnum)))
                {
                    countDict[type] += dict[type];
                }
            }
            return countDict;
        }
    }
}

