using eShift_Logistics_System.Helpers;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Service
{
    public class UserRepository: IUserRepository
    {
        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            string query = @"
                INSERT INTO Users 
                (first_name, email, user_type, phone, password_hash, customer_number) 
                VALUES 
                (@first_name, @email, @user_type, @phone, @password_hash, @customer_number)";

            DatabaseHelper.ExecuteNonQuery(query, command =>
            {
                command.Parameters.AddWithValue("@first_name", user.FullName);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@user_type", (int)user.UserType);
                command.Parameters.AddWithValue("@phone", user.Phone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@password_hash", CommonHelper.HashPassword(user.PasswordHash));
                command.Parameters.AddWithValue("@customer_number", CommonHelper.GenerateCustomerNumber());
            });
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        List<User> IUserRepository.GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
