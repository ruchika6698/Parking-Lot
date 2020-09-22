using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserBusinessLayer : IUserBusinessLayer
    {
        private IUserRepositoryLayer _UserRepository;
        public UserBusinessLayer(IUserRepositoryLayer UserRepository)
        {
            _UserRepository = UserRepository;
        }
        /// <summary>
        ///  API for Registrion
        /// </summary>
        /// <param name="data"> store the Complete Employee information</param>
        /// <returns></returns>
        public async Task<bool> UserRegister(Usermodel data)
        {
            try
            {
                var Result = await _UserRepository.UserRegister(data);
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
        ///  API for Login
        /// </summary>
        /// <param name="data"> Login API</param>
        /// <returns></returns>
        public async Task<int> UserLogin(Login data)
        {
            try
            {
                var Result = await _UserRepository.UserLogin(data);
                //if result is not equal null then return true
                if (!Result.Equals(0))
                {
                    return 1;
                }
                else
                {
                    return 0;
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
        public IEnumerable<UserDetails> GetAllUser()
        {
            try
            {
                return _UserRepository.GetAllUser();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
