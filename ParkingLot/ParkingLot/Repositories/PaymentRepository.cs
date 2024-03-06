using System;
using ParkingLot.Models;

namespace ParkingLot.Repositories
{
    public class PaymentRepository
    {
        private Dictionary<long, Payment> Payments = new Dictionary<long, Payment>();
        public long IdCount = 0;

        public long Save(Payment payment)
        {
            Payments[IdCount++] = payment;
            return IdCount - 1;
        }

        public Payment? GetPaymentById(long id)
        {
            if (!Payments.ContainsKey(id)) return null;
            return Payments[id];
        }
    }
}

