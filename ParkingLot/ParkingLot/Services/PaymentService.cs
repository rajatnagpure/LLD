using ParkingLot.Models;
using ParkingLot.Repositories;

namespace ParkingLot.Services
{
    public class PaymentService
    {
        private PaymentRepository PaymentRepository;
        public PaymentService(PaymentRepository paymentRepository)
        {
            PaymentRepository = paymentRepository;
        }
        public Payment MakePayment(float finalAmount)
        {
            // calling the payment gateway here
            System.Console.WriteLine("Enter the amount you want to pay this time, Unpaid Amount is: "+finalAmount);
            int amount = Convert.ToInt32(Console.ReadLine());
            Payment payment = new Payment(PaymentRepository.IdCount, amount);
            payment.setPaymentDone();
            PaymentRepository.Save(payment);
            return payment;
        }
    }
}

