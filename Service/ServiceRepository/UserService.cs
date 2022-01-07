using DAL.Interfaces;
using Service.ServiceInterface;
using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ServiceRepository
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool CreateUser(RegisterUser registerUser)
        {
            // Some validation to check user already exist

            bool registered = false;
            var user = _userRepository.GetUserByEmail(registerUser.Email);
            if(user == null)
            {
                _userRepository.CreateUser(registerUser);
                registered = true;
                return registered;
            }

            else
            {
                return registered;
            }
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

    }
}
