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
        private IConfiguration _config;
        IParkingBusinessLayer BusinessLayer;

        public ParkingController(IParkingBusinessLayer BusinessDependencyInjection, IConfiguration config)
        {
            BusinessLayer = BusinessDependencyInjection;
            _config = config;
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
                    var status = "True";
                    var Message = "Parking Vehicle Registration Successfull";
                    return this.Ok(new { status, Message, Info });
                }
                else                                     //Parking Vehicle Registration Fail
                {
                    var status = "False";
                    var Message = "Parking Vehicle Registration Failed";
                    return this.BadRequest(new { status, Message, data = Info });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
    }
}