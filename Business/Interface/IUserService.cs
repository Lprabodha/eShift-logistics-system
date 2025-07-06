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
        void DeleteUser(int id);
        /// <summary>
        /// Retrieves all users in the system.
        /// </summary>
        /// <returns>A list of all users.</returns>
        List<User> GetAllUsers();
    }
}
