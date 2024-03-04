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
        void FillSpot()
        {
            Filled = true;
        }
        void EmptySpot()
        {
            Filled = false;
        }
    }
}

