///-----------------------------------------------------------------
///   Class:       IUserBusinessLayer
///   Description: Business Layer Interface for User
///   Author:      Ruchika                   Date: 21/9/2020
///-----------------------------------------------------------------
using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IUserBusinessLayer
    {
        //Interface method for User Registration
        Task<bool> UserRegister(Usermodel data);

        //Interface method for User Login
        Task<int> UserLogin(Login data);
    }
}
