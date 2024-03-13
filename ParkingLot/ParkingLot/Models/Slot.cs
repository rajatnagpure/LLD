using System;
namespace ParkingLot.Models
{
    public class Slot : BaseModel
    {
        public VehicleTypeEnum VehicleType { private set; get; }
        public bool Filled { private set; get; }
        public Slot(long id, VehicleTypeEnum vehicleType) : base(id)
        {
            VehicleType = vehicleType;
            Filled = false;
        }
        public void FillSpot()
        {
            Filled = true;
        }
        public void EmptySpot()
        {
            Filled = false;
        }
    }
}

