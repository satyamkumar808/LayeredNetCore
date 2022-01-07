using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ServiceInterface
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        bool CreateUser(RegisterUser registerUser);
    }
}
