using ParkingLot.Strategies;

namespace ParkingLot.Models
{
    public class ParkingLot: BaseModel
    {
        public int MaxFloors { private set; get; }
        public int MaxSlots { private set; get; }
        public List<Floor> Floors { private set; get; }
        public SlotFindingStrategyInterface SlotFindingStrategy { private set; get; }
        private ParkingLot(int id) : base(id) { }
        private long ticketCount = 0;
        private long paymentCount = 0;
        public class Builder
        {
            private int MxFloors;
            private int MxSlots;
            private SlotFindingStrategyEnum SlotFindingStrategyEnum;
            public void SetMaxFloorCount(int mxFloors)
            {
                MxFloors = mxFloors;
            }
            public void SetMaxSlotCount(int mxSlots)
            {
                MxSlots = mxSlots;
            }
            public void SetSlotFindingStrategyEnum(SlotFindingStrategyEnum slotFindingStrategyEnum)
            {
                SlotFindingStrategyEnum = slotFindingStrategyEnum;
            }
            public ParkingLot Build(int id)
            {
                int slotIdCount = 0;
                if (MxSlots < 4) throw new InvalidOperationException("Slots per floor cannot be less than 4");
                if (MxFloors < 1) throw new InvalidOperationException("Floors cannot be zero");
                List<Floor> floors = new List<Floor>();
                Floor floor;
                for(int i = 0; i < MxFloors; i++)
                {
                    floor = new Floor(i);
                    floor.Initialise(MxSlots, slotIdCount++);
                    floors.Add(floor);
                }
                ParkingLot parkingLot = new ParkingLot(id);
                parkingLot.MaxFloors = MxFloors;
                parkingLot.MaxSlots = MxSlots;
                parkingLot.Floors = floors;
                parkingLot.SlotFindingStrategy = SlotFindingStrategyFactory.getSlotFindingStrategy(SlotFindingStrategyEnum);
                return parkingLot;
            }
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
        public Dictionary<VehicleTypeEnum, int> GetFreeSlots()
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
        public Ticket ParkVehicle(Vehicle vehicle)
        {
            Floor? floor = null;
            Slot? slot = null;
            foreach(var flr in Floors)
            {
                long slotIdx = SlotFindingStrategy.EmptySlot(flr, vehicle.VehicleType);
                if (slotIdx != -1)
                {
                    floor = flr;
                    slot = flr.Slots[(int)slotIdx];
                    break;
                }
            }
            if (floor == null || slot == null) throw new InvalidOperationException("Empty Slot Not Found");
            return new Ticket(ticketCount++, vehicle, slot, floor);
        }
        private Payment GetPayment(Ticket ticket)
        {
            System.Console.WriteLine("Amount unpaid: " + ticket.GetUnpaidAmount() + " Enter amount for this Payment: ");
            float.TryParse(System.Console.ReadLine(), out float amount);
            Payment payment = new Payment(paymentCount++, amount);
            System.Console.WriteLine("Is payment Successful: Press y for yes otherwise anyother key");
            char key = Console.ReadKey().KeyChar;
            if (key == 'y') payment.setPaymentDone();
            return payment;
        }
        public bool UnParkVehicle(Ticket ticket)
        {
            ticket.FinalizeExitVehicle();
            while (true)
            {
                Console.WriteLine("To make Remaining Payment press r otherwise anyother key: ");
                char key = Console.ReadKey().KeyChar;
                if (key == 'r') ticket.MakePayment(GetPayment(ticket));
                else break;
            }
            return ticket.PaymentAllClear();
        }
    }
}

