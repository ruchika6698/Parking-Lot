using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IParkingBusinessLayer
    {
        //Interface method for Parking Vehicle Registration
        Task<bool> VehicleParking(VehicleModel data);
    }
}
