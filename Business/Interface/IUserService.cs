using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Interface
{
    internal interface IUserService
    {
        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="user">The user to add.</param>
        void AddUser(User user);
        /// <summary>
        /// Updates an existing user's information.
        /// </summary>
        /// <param name="user">The user with updated information.</param>
        void UpdateUser(User user);
        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        bool DeleteUser(string customerNumber);

        /// <summary>
        /// Retrieves all users in the system.
        /// </summary>
        /// <returns>A list of all users.</returns>
        List<User> GetAllUsers();

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="customerNumber"></param>
        /// <returns></returns>
        bool ToggleUserStatus(string customerNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User AuthenticateUser(string email, string password);

        /// <summary>
        /// Retrieves the count of active customers in the system.
        /// </summary>
        /// <returns></returns>
        int GetActiveCustomerCount();

        /// <summary>
        /// Retrieves a user by their email address.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserById(int id);

        /// <summary>
        /// Checks if an email already exists in the system.
        /// </summary>
        /// <param name="user"></param>
        void UpdateUserProfile(User user);

        /// <summary>
        /// Checks if an email already exists in the system.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="currentPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        bool ChangePassword(int userId, string currentPassword, string newPassword);
    }
}
