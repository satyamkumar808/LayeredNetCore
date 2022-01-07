using DAL;
using DAL.Interfaces;
using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private OrdersContext _context;
        public UserRepository(OrdersContext context)
        {
            _context = context;
        }

        public void CreateUser(RegisterUser registerUser)
        {

            User user = new User
            {
                UserName = registerUser.UserName,
                Email = registerUser.Email,
                Password = registerUser.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public  User GetUserByEmail(string email)
        {
            User user = new User();
            user = _context.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }
    }
}
