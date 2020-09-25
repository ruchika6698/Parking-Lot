using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class ParkingDetails
    {
        public int ParkingID { get; set; }
        public int UserID { get; set; }
        public string VehicleOwnerAddress { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicalBrand { get; set; }
        public string VehicalColor { get; set; }
        public string ParkingSlot { get; set; }
        public string ParkingUserCategory { get; set; }
        public string ParkingStatus { get; set; }
        public string Charges { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
    }
}
