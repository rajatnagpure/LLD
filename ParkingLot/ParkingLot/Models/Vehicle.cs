namespace ParkingLot.Models
{
    public class Vehicle : BaseModel
    {
        public VehicleTypeEnum VehicleType { private set; get; }
        public long Colour { private set; get; }
        public String RegNum { private set; get; }
        public Vehicle(long id, String regNum, long colour, VehicleTypeEnum vehicle): base(id)
        {
            RegNum = regNum;
            Colour = colour;
            VehicleType = VehicleType;
        }
    }
}

