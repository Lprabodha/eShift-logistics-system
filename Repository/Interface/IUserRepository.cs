using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Interface
{
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves all users from the repository.
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();

        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="user"></param>
        void AddUser(User user);

        /// <summary>
        /// Updates an existing user's information in the repository.
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(User user);

        /// <summary>
        /// Deletes a user from the repository by their ID.
        /// </summary>
        /// <param name="id"></param>
        void DeleteUser(int id);

        /// <summary>
        /// Checks if an email already exists in the repository.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool IsEmailExists(string email);

        /// <summary>
        /// Checks if a phone number already exists in the repository.
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        bool IsPhoneExists(string phone);

        /// <summary>
        /// Retrieves a user by their email address from the repository.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        User GetUserByEmail(string email);

    }
}
