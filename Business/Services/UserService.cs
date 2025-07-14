using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Helpers;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using eShift_Logistics_System.Repository.Service;
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

        public bool DeleteUser(string customerNumber)
        {
            var user = _userService.GetAllUsers()
                                      .FirstOrDefault(u => u.CustomerNumber == customerNumber);
            if (user == null) return false;

            return _userService.DeleteUser(user.Id);
        }

        public void UpdateUser(User user)
        {
            _userService.UpdateUser(user ?? throw new ArgumentNullException(nameof(user)));
        }

        List<User> IUserService.GetAllUsers()
        {
            return _userService.GetAllUsers() ?? new List<User>();
        }

        public bool ToggleUserStatus(string customerNumber)
        {
            return _userService.ToggleUserStatus(customerNumber);
        }

        public User AuthenticateUser(string email, string password)
        {
            var user = _userService.GetUserByEmail(email);

            if (user != null && user.IsActive)
            {
                if (CommonHelper.VerifyPassword(password, user.PasswordHash))
                {
                    return user; 
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetActiveCustomerCount()
        {
            return _userService.GetAllUsers().Count(u => u.IsActive && u.UserType == UserType.Customer);
        }

        /// <summary>
        /// /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        /// <summary>
        /// /// Updates the profile of the currently logged-in user.
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUserProfile(User user)
        {
            _userService.UpdateUserProfile(user);
        }

        /// <summary>
        /// /// Changes the password for a user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="currentPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ChangePassword(int userId, string currentPassword, string newPassword)
        {
            var currentPasswordHash = CommonHelper.HashPassword(currentPassword);
            var newPasswordHash = CommonHelper.HashPassword(newPassword);

            return _userService.ChangePassword(userId, currentPasswordHash, newPasswordHash);
        }

    }
}
