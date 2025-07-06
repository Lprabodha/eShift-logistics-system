using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userService;

        public UserService(IUserRepository userService)
        {
            _userService = userService;
        }

        public void AddUser(User user)
        {
            _userService.AddUser(user);

        }

        public void DeleteUser(int id)
        {
            _userService.DeleteUser(id);

        }

        public void UpdateUser(User user)
        {
            _userService.UpdateUser(user ?? throw new ArgumentNullException(nameof(user)));
        }

        List<User> IUserService.GetAllUsers()
        {
            return _userService.GetAllUsers() ?? new List<User>();
        }

    }
}
