using ParkingLot.Repositories;
using ParkingLot.Services;
using ParkingLot.Models;

ParkingLotRepository parkingLotRepository = new ParkingLotRepository();
PaymentRepository paymentRepository = new PaymentRepository();
TicketRepository ticketRepository = new TicketRepository();
VehicleRepository vehicleRepository = new VehicleRepository();

ParkingLotService parkingLotService = new ParkingLotService(parkingLotRepository);
PaymentService paymentService = new PaymentService(paymentRepository);
TicketService ticketService = new TicketService(ticketRepository, vehicleRepository, parkingLotRepository, paymentService);

System.Console.WriteLine("Starting ParkingLot!! Please insert the command to Perform Opetaions");
string? currentparkingLotId = null;

while (true)
{
    string? command = System.Console.ReadLine();
    if (command == null) break;
    if (command == "exit") break;
    string[]? arguments = command.Split();
    switch (arguments[0])
    {
        case "create_parking_lot":
            currentparkingLotId = arguments[1];
            int mxFloors = Convert.ToInt32(arguments[2]);
            int mxSlots = Convert.ToInt32(arguments[3]);
            
            try
            {
                parkingLotService.CreateParkingLot(currentparkingLotId, mxFloors, mxSlots, SlotFindingStrategyEnum.FIRST_EMPTY);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            break;
        case "park_vehicle":
            VehicleTypeEnum vehicleType = (VehicleTypeEnum)Convert.ToInt32(arguments[1]);
            string regNum = arguments[2].ToLower();
            long color = Convert.ToInt32(arguments[3]);
            try
            {
                long tId = ticketService.ParkVehicle(currentparkingLotId, regNum, color, vehicleType);
                System.Console.WriteLine("Ticket OD: " + tId);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            break;
        case "unpark_vehicle":
            long ticketId = Convert.ToInt32(arguments[1]);
            try
            {
                Vehicle vehicle = ticketService.UnParkVehicle(ticketId);
                System.Console.WriteLine("Unpaarked vehicle with Registration Number: " + vehicle.RegNum + " and Color: " + vehicle.Colour);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            break;
        case "display":
            VehicleTypeEnum type = (VehicleTypeEnum)Convert.ToInt32(arguments[2]);
            ParkingLot.Models.ParkingLot parkingLot = parkingLotRepository.GetParkingLotById(currentparkingLotId);
            switch (arguments[1])
            {
                case "free_count":
                    for(int i = 0; i < parkingLot?.Floors.Count; i++)
                    {
                        System.Console.WriteLine("No. of free slots for " + type.ToString() + " on Floor " + i + ": " + parkingLot.Floors[i].GetFreeSlotByType(type));
                    }
                    break;
                case "occupied_count":
                    for (int i = 0; i < parkingLot?.Floors.Count; i++)
                    {
                        System.Console.WriteLine("No. of occupied slots for " + type.ToString() + " on Floor " + i + ": " + parkingLot.Floors[i].GetAllFilledSlotCount()[type]);
                    }
                    break;
            }
            break;
    }
}