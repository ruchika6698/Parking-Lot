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
        //Interface method for user Registration
        Task<bool> UserRegister(Usermodel data);
        //Interface method for user Login
        Task<int> UserLogin(Login data);

        //Interface method for get all user detail
        IEnumerable<UserDetails> GetAllUser();
    }
}
