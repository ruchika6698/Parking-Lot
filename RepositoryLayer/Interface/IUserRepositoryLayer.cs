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
        UserDetails UserLogin(Login user);
        //Interface method for delete User detail
        UserID DeleteUser(int ID);
        //Interface method for get User detail by id
        UserDetails Getspecificuser(int ID);
        //Interface method for get all user detail
        IEnumerable<UserDetails> GetAllUser();
    }
}
