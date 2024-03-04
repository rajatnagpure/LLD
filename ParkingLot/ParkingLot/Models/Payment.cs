namespace ParkingLot.Models
{
    public class Payment: BaseModel
    {
        public float Amount { private set; get; }
        public bool PaymentDone { private set; get; }
        public Payment(long id, float amount): base(id)
        {
            PaymentDone = false;
            Amount = amount;
        }
        public void setPaymentDone()
        {
            PaymentDone = true;
        }
    }
}

