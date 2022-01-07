using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserByEmail(string email);

        void CreateUser(RegisterUser registerUser);
    }
}
