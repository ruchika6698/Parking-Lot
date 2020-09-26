﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class VehicleModel
    {
        [Required(ErrorMessage = "User ID Is Required")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Vehicle owner address Is Required")]
        public string VehicleOwnerAddress { get; set; }

        [Required(ErrorMessage = "Vehicle Number Is Required")]
        public string VehicleNumber { get; set; }

        [Required(ErrorMessage = "Vehical Brand Is Required")]
        public string VehicalBrand { get; set; }

        [Required(ErrorMessage = "Vehical Color Is Required")]
        public string VehicalColor { get; set; }

        [Required(ErrorMessage = "Parking Slot Is Required")]
        public string ParkingSlot { get; set; }

        [Required(ErrorMessage = "Parking User Category Is Required")]
        public string ParkingUserCategory { get; set; }

        [Required(ErrorMessage = "Parking Status Is Required")]
        public string ParkingStatus { get; set; }

        [Required(ErrorMessage = "Charges Is Required")]
        public string Charges { get; set; }


        //Entry time
        public DateTime EntryTime { get; set; }

        //Exit time
        public DateTime ExitTime { get; set; }
    }
}
