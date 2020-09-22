///-----------------------------------------------------------------
///   Class:       UserModel
///   Description: Poco class for all Parking Login
///   Author:      Ruchika                   Date: 21/9/2020
///-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class Login
    {
        [Required(ErrorMessage = "Username Is Required")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [RegularExpression("^.{8,30}$", ErrorMessage = "Password Length should be between 8 to 15")]
        public string Password { get; set; }

        [MaxLength(50)]
        //User Role
        public string UserRole { get; set; }
    }
}
