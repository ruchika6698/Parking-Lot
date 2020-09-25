///-----------------------------------------------------------------
///   Class:       IParkingRepositoryLayer
///   Description: Business Layer Interface for Parking
///   Author:      Ruchika                   Date: 25/9/2020
///-----------------------------------------------------------------
using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IParkingRepositoryLayer
    {
        //Interface method for Parking Vehicle Registration
        Task<bool> VehicleParking(VehicleModel data);

        //Interface method for get Parking detail by id
        ParkingDetails GetspecificParkingDetails(int ParkingID);

        //Interface method for get all Parking Vehicle detail
        IEnumerable<ParkingDetails> GetAllParkingDetails();
    }
}
