using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ParkingLotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        IParkingBusinessLayer BusinessLayer;

        public ParkingController(IParkingBusinessLayer BusinessDependencyInjection, IConfiguration config)
        {
            BusinessLayer = BusinessDependencyInjection;
        }

        /// <summary>
        ///  API for Parking Entry of Vehicle
        /// </summary>
        /// <param name="Info"> store the Complete Parking Vehicle information</param>
        /// <returns></returns>
        [Route("Vehicleparking")]
        [HttpPost]
        public async Task<IActionResult> VehicleParking([FromBody] VehicleModel Info)
        {
            try
            {
                bool data = await BusinessLayer.VehicleParking(Info);
                //if data is not equal to null then Parking Vehicle Registration sucessful
                if (!data.Equals(null))
                {
                    var Success = "True";
                    var Message = "Parking Vehicle Registration Successfull";
                    return this.Ok(new { Success, Message, Info });
                }
                else                                     //Parking Vehicle Registration Fail
                {
                    var Success = "False";
                    var Message = "Parking Vehicle Registration Failed";
                    return this.BadRequest(new { Success, Message, data = Info });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for get specific Parking details
        /// </summary>
        /// <param name="ParkingID">get specific  data</param>
        /// <returns></returns>
        [HttpGet("{ParkingID}")]
        //[Authorize(Roles = "Owner")]
        public IActionResult GetspecificParkingDetails(int ParkingID)
        {
            try
            {
                var result = BusinessLayer.GetspecificParkingDetails(ParkingID);
                //if result is not equal to zero then details found
                if (!result.Equals(null))
                {
                    var Success = "True";
                    var Message = "Parking Details found ";
                    return this.Ok(new { Success, Message, Data = result });
                }
                else                                           //Data is not found
                {
                    var Success = "False";
                    var Message = "Parking Details not found";
                    return this.BadRequest(new { Success, Message, Data = result });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for get all Parking Vehicles details
        /// </summary>
        [HttpGet]
        //[Authorize(Roles = "Owner")]
        public ActionResult<IEnumerable<ParkingDetails>> GetAllParkingDetails()
        {
            try
            {
                var result = BusinessLayer.GetAllParkingDetails();
                //if result is not equal to zero then details found
                if (!result.Equals(null))
                {
                    var Success = "True";
                    var Message = "Parking Details found ";
                    return this.Ok(new { Success, Message, Data = result });
                }
                else                                           //Data is not found
                {
                    var Success = "False";
                    var Message = "Parking Details not found";
                    return this.BadRequest(new { Success, Message, Data = result });
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}