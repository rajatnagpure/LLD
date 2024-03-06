using ParkingLot.Models;
using ParkingLot.Repositories;

namespace ParkingLot.Services
{
    public class TicketService
    {
        private TicketRepository TicketRepository;
        private VehicleRepository VehicleRepository;
        private ParkingLotRepository ParkingLotRepository;
        private PaymentService PaymentService;
        public TicketService(TicketRepository ticketRepository,
            VehicleRepository vehicleRepository,
            ParkingLotRepository parkingLotRepository,
            PaymentService paymentService)
        {
            TicketRepository = ticketRepository;
            VehicleRepository = vehicleRepository;
            ParkingLotRepository = parkingLotRepository;
            PaymentService = paymentService;
        }
        public Ticket ParkVehicle(long parkingLotId, Vehicle vehicle)
        {
            Models.ParkingLot? parkingLot = ParkingLotRepository.GetParkingLotById(parkingLotId);
            if (parkingLot == null) throw new InvalidOperationException("Invalid ParkingLotId");
            if(VehicleRepository.GetVehicleById(vehicle.Id) == null)
            {
                vehicle.Id = VehicleRepository.IdCount + 1;
                VehicleRepository.Save(vehicle);
            }
  
            Floor? floor = null;
            Slot? slot = null;
            foreach (var flr in parkingLot.Floors)
            {
                long slotIdx = parkingLot.SlotFindingStrategy.EmptySlot(flr, vehicle.VehicleType);
                if (slotIdx != -1)
                {
                    floor = flr;
                    slot = flr.Slots[(int)slotIdx];
                    break;
                }
            }
            if (floor == null || slot == null) throw new InvalidOperationException("Empty Slot Not Found");
            return new Ticket(TicketRepository.IdCount+1, vehicle, slot, floor);
        }
        private float GetFinalAmount(Ticket ticket)
        {
            TimeSpan timeDiff = ((TimeSpan)(ticket.ExitTime! - ticket.EntryTime));
            float ratePerHour;
            switch (ticket.Vehicle.VehicleType)
            {
                case VehicleTypeEnum.TRUCK:
                    ratePerHour = 4;
                    break;
                case VehicleTypeEnum.BIKE:
                    ratePerHour = 1;
                    break;
                case VehicleTypeEnum.CAR:
                default:
                    ratePerHour = 2;
                    break;
            }
            return ratePerHour * timeDiff.Hours;
        }
        public bool UnParkVehicle(long ticketId)
        {
            Ticket? ticket = TicketRepository.GetTicketById(ticketId);
            if (ticket == null) throw new InvalidOperationException("Invalid TicketId");
            
            ticket.FinalizeExitVehicle(GetFinalAmount(ticket));
            while (true)
            {
                Console.WriteLine("To make Remaining Payment press r otherwise anyother key: ");
                char key = Console.ReadKey().KeyChar;
                if (key == 'r') ticket.Payments.Add(PaymentService.MakePayment(ticket.GetUnpaidAmount()));
                else break;
            }
            return ticket.PaymentAllClear();
        }
        public bool PaymentAllClear(long ticketId)
        {
            Ticket? ticket = TicketRepository.GetTicketById(ticketId);
            if (ticket == null) throw new InvalidOperationException("Invalid TicketId");
            float recievedAmount = 0;
            foreach (var payment in ticket.Payments)
            {
                if (payment.PaymentDone)
                    recievedAmount += payment.Amount;
            }
            return (recievedAmount == ticket.FinalAmount);
        }
        public float GetUnpaidAmount(long ticketId)
        {
            Ticket? ticket = TicketRepository.GetTicketById(ticketId);
            if (ticket == null) throw new InvalidOperationException("Invalid TicketId");
            float recievedAmount = 0;
            foreach (var payment in ticket.Payments)
            {
                if (payment.PaymentDone)
                    recievedAmount += payment.Amount;
            }
            return recievedAmount;
        }
    }
}

