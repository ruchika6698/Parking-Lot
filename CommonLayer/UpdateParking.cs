///-----------------------------------------------------------------
///   Class:       UpdateModel
///   Description: Poco class for all update Parking details
///   Author:      Ruchika                   Date: 18/5/2020
///-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class UpdateParking
    {
        public string ParkingStatus { get; set; }
        public DateTime ExitTime { get; set; } = DateTime.Now;
    }
}
