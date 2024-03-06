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
                if (slot.Filled == false)
                    emptySlotByType[slot.VehicleType]++;
            }
            return emptySlotByType;
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

