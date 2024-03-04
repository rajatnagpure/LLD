namespace ParkingLot.Models
{
    public class Ticket: BaseModel
    {
        public Vehicle Vehicle { private set; get; }
        public DateTime EntryTime { private set; get; }
        public DateTime? ExitTime { private set; get; }
        public Slot AllotedSlot { private set; get; }
        public Floor Floor { private set; get; }
        public List<Payment> Payments { private set; get; }
        public float FinalAmount { private set; get; }
        public Ticket(long id, Vehicle vehicle, Slot slot, Floor floor): base(id)
        {
            Vehicle = vehicle;
            EntryTime = DateTime.Now;
            AllotedSlot = slot;
            Floor = floor;
            ExitTime = null;
            FinalAmount = 0;
        }
        private float GetFinalAmount()
        {
            TimeSpan timeDiff = ((TimeSpan)(ExitTime! - EntryTime));
            float ratePerHour = 1;
            switch (Vehicle.VehicleType)
            {
                case VehicleTypeEnum.TRUCK: ratePerHour = 4;
                    break;
                case VehicleTypeEnum.BIKE: ratePerHour = 1;
                    break;
                case VehicleTypeEnum.CAR:
                default:
                    ratePerHour = 2;
                    break;
            }
            return ratePerHour * timeDiff.Hours;
        }
        public void FinalizeExitVehicle()
        {
            ExitTime = DateTime.Now;
            FinalAmount = GetFinalAmount();
        }
        public void MakePayment(Payment payment)
        {
            Payments.Add(payment);
        }
        public bool PaymentAllClear()
        {
            float recievedAmount = 0;
            foreach(var payment in Payments)
            {
                if(payment.PaymentDone)
                    recievedAmount += payment.Amount;
            }
            return (recievedAmount == FinalAmount);
        }
        public float GetUnpaidAmount()
        {
            float recievedAmount = 0;
            foreach (var payment in Payments)
            {
                if (payment.PaymentDone)
                    recievedAmount += payment.Amount;
            }
            return recievedAmount;
        }
    }
}

