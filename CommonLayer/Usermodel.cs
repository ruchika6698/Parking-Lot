///-----------------------------------------------------------------
///   Class:       UserModel
///   Description: Poco class for all Parking User Details
///   Author:      Ruchika                   Date: 21/9/2020
///-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
        public class Usermodel
        {
            [Required(ErrorMessage = "User Name Is Required")]
            [RegularExpression("^[A-Z][a-zA-Z]{3,15}$", ErrorMessage = "First Name is not valid")]
            public string FirstName { get; set; }

            [RegularExpression("^[A-Z][a-zA-Z]{3,15}$", ErrorMessage = "Last Name is not valid")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "EmailID Is Required")]
            [RegularExpression("^[a-zA-Z0-9]{1,}([.]?[-]?[+]?[a-zA-Z0-9]{1,})?[@]{1}[a-zA-Z0-9]{1,}[.]{1}[a-z]{2,3}([.]?[a-z]{2})?$", ErrorMessage = "E-mail is not valid")]
            public string EmailID { get; set; }

            [Required(ErrorMessage = "Password Is Required")]
            [RegularExpression("^.{8,15}$", ErrorMessage = "Password Length should be between 8 to 15")]
            public string Password { get; set; }

            [Required(ErrorMessage = "User Role Is Required")]

            [RegularExpression("^[A-Z][a-zA-Z]{3,15}$", ErrorMessage = "User Role is not valid")]
            public string UserRole { get; set; }

            //Create date 
            public DateTime CreateDate { get; set; } = DateTime.Now;
        }
}
