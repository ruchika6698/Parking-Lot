///-----------------------------------------------------------------
///   Class:       IUserRepository
///   Description: Repository Layer Interface for User
///   Author:      Ruchika                   Date: 21/9/2020
///-----------------------------------------------------------------
using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IUserRepositoryLayer
    {
        //Interface method for Employee Registration
        Task<bool> UserRegister(Usermodel data);
        //Interface method for Employee Login
        Task<int> UserLogin(Login data);
    }
}
