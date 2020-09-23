using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ParkingLotAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        IUserBusinessLayer BusinessLayer;

        public UserController(IUserBusinessLayer BusinessDependencyInjection, IConfiguration config)
        {
            BusinessLayer = BusinessDependencyInjection;
            _config = config;
        }

        /// <summary>
        ///  API for Registrion
        /// </summary>
        /// <param name="Info"> store the Complete Employee information</param>
        /// <returns></returns>
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> UserRegister([FromBody] Usermodel Info)
        {
            try
            {
                bool data = await BusinessLayer.UserRegister(Info);
                //if data is not equal to null then Registration sucessful
                if (!data.Equals(null))
                {
                    var status = "True";
                    var Message = "Registration Successfull";
                    return this.Ok(new { status, Message, Info });
                }
                else                                     //Registration Fail
                {
                    var status = "False";
                    var Message = "Registration Failed";
                    return this.BadRequest(new { status, Message, data = Info });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        /// <summary>
        ///  API for Login
        /// </summary>
        /// <param name="Info"> Login API</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> UserLogin([FromBody] Login Info)
        {
            try
            {
                int Result = await BusinessLayer.UserLogin(Info);
                var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

                var signingCreds = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, Info.UserRole.ToString()),
                    new Claim("EmailID ", Info.EmailID.ToString())
                };
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddHours(120),
                    signingCredentials: signingCreds);
                //if Result is not equal to null then Login sucessful
                if (Result != 0)
                {
                    var status = "True";
                    var Message = "Login Successful";
                    var Token = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new { status, Message, Token});
                }
                else                                        //Username or Password Incorrect
                {
                    var status = "False";
                    var Message = "Invaid Username Or Password";
                    return BadRequest(new { status, Message, Result = Info });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for Delete data
        /// </summary>
        /// <param name="ID">Delete data</param>
        /// <returns></returns>
        /*[HttpDelete("{ID}")]
        public IActionResult DeleteUser(int ID)
        {
            try
            {
                var result = BusinessLayer.DeleteUser(ID);
                //if result is not equal to zero then details Deleted sucessfully
                if (!result.Equals(null))
                {
                    var Status = "True";
                    var Message = "User Data deleted Sucessfully";
                    return this.Ok(new { Status, Message, Data = ID });
                }
                else                                           //Data is not deleted 
                {
                    var Status = "False";
                    var Message = "User Data is not deleted Sucessfully";
                    return this.BadRequest(new { Status, Message, Data = ID });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }*/

        // <summary>
        ///  API for get specific User  details
        /// </summary>
        /// <param name="ID">Update data</param>
        /// <returns></returns>
        [HttpGet("{ID}")]
        //[Authorize(Roles = "Owner")]
        public IActionResult Getspecificuser(int ID)
        {
            try
            {
                var result = BusinessLayer.Getspecificuser(ID);
                //if result is not equal to zero then details found
                if (!result.Equals(null))
                {
                    var Status = "True";
                    var Message = "User Data found ";
                    return this.Ok(new { Status, Message, Data = result });
                }
                else                                           //Data is not found
                {
                    var Status = "False";
                    var Message = "User Data is not found";
                    return this.BadRequest(new { Status, Message, Data = result });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for get all User details
        /// </summary>
        [HttpGet]
        //[Authorize(Roles = "Owner")]
        public ActionResult<IEnumerable<UserDetails>> GetAllUser()
        {
            try
            {
                //var user = HttpContext.User; 
                //int EmailID = Convert.ToInt32(user.Claims.FirstOrDefault(u => u.Type == "EmailID").Value);
                var result = BusinessLayer.GetAllUser();
                //if result is not equal to zero then details found
                if (!result.Equals(null))
                {
                    var Status = "True";
                    var Message = "User Data found ";
                    return this.Ok(new { Status, Message, Data = result });
                }
                else                                           //Data is not found
                {
                    var Status = "False";
                    var Message = "User Data is not found";
                    return this.BadRequest(new { Status, Message, Data = result });
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}