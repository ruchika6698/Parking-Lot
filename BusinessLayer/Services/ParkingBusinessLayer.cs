///-----------------------------------------------------------------
///   Class:       ParkingBusinessLayer
///   Description: Business Layer Services for Parking
///   Author:      Ruchika                   Date: 25/9/2020
///-----------------------------------------------------------------
using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ParkingBusinessLayer : IParkingBusinessLayer
    {
        private IParkingRepositoryLayer _ParkingRepository;
        public ParkingBusinessLayer(IParkingRepositoryLayer ParkingRepository)
        {
            _ParkingRepository = ParkingRepository;
        }

        /// <summary>
        ///  API for Parking Entry of Vehicle
        /// </summary>
        /// <param name="data"> store the Complete Parking Vehicle information</param>
        /// <returns></returns>
        public async Task<bool> VehicleParking(VehicleModel data)
        {
            try
            {
                var Result = await _ParkingRepository.VehicleParking(data);
                //if result is not equal null then return true
                if (!Result.Equals(null))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for Update Excisting entry
        /// </summary>
        /// <param name="ParkingID">Primary key</param>
        /// <param name="data">Update data</param>
        /// <returns></returns>
        public int UpdateParkingDetail(int ParkingID, UpdateParking data)
        {
            try
            {
                var result = _ParkingRepository.UpdateParkingDetail(ParkingID, data);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for get specific User details
        /// </summary>
        /// <param name="ID"> get specific Entry</param>
        /// <returns></returns>
        public ParkingDetails GetspecificParkingDetails(int ParkingID)
        {
            try
            {
                return _ParkingRepository.GetspecificParkingDetails(ParkingID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for get all Vehicle parking details
        /// </summary>
        public IEnumerable<ParkingDetails> GetAllParkingDetails()
        {
            try
            {
                return _ParkingRepository.GetAllParkingDetails();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
