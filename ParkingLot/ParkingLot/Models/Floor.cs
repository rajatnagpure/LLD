namespace ParkingLot.Models
{
    public class Floor: BaseModel
    {
        public List<Slot> Slots { private set; get; }
        public Floor(int id): base(id)
        {
            Slots = new List<Slot>();
        }
        public bool IsFloorFull()
        {
            return !Slots.Any(x => x.Filled == false);
        }
        public Dictionary<VehicleTypeEnum, int> GetAllEmptySlotCount()
        {
            Dictionary<VehicleTypeEnum, int> emptySlotByType = new Dictionary<VehicleTypeEnum, int>();
            foreach(var slot in Slots)
            {
                if (!emptySlotByType.ContainsKey(slot.VehicleType))
                    emptySlotByType.Add(slot.VehicleType, 0);
                if (!slot.Filled)
                    emptySlotByType[slot.VehicleType]++;
            }
            return emptySlotByType;
        }
        public Dictionary<VehicleTypeEnum, int> GetAllFilledSlotCount()
        {
            Dictionary<VehicleTypeEnum, int> filledSlotByType = new Dictionary<VehicleTypeEnum, int>();
            foreach (var slot in Slots)
            {
                if (!filledSlotByType.ContainsKey(slot.VehicleType))
                    filledSlotByType.Add(slot.VehicleType, 0);
                if (slot.Filled)
                    filledSlotByType[slot.VehicleType]++;
            }
            return filledSlotByType;
        }
        public int GetFreeSlotByType(VehicleTypeEnum vehicleType)
        {
            int count = 0;
            foreach(var slot in Slots)
            {
                if (slot.VehicleType == vehicleType && !slot.Filled) count++;
            }
            return count;
        }
    }
}

