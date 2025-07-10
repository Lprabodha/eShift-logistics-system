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
            List<User>  users = new List<User>();
            string query = "SELECT * FROM users WHERE user_type=1";

            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {

                    using(var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                FirstName = reader["first_name"].ToString(),
                                Email = reader["email"].ToString(),
                                Phone = reader["phone"]?.ToString(),
                                PasswordHash = reader["password_hash"].ToString(),
                                UserType = (UserType)Convert.ToInt32(reader["user_type"]),
                                CustomerNumber = reader["customer_number"]?.ToString(),
                                IsActive = Convert.ToInt32(reader["is_active"]) == 1

                            });
                        }
                    }
                    return users;

                }
                catch(Exception ex)
                {
                    throw new Exception("Error retrieving users from the database.", ex);
                }
            }


        }

        /// <summary>
        /// Checks if an email already exists in the database.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsEmailExists(string email)
        {
            using var conn = DatabaseHelper.GetConnection();
            string query = "SELECT COUNT(*) FROM users WHERE email = @email";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@email", email);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        /// <summary>
        /// Checks if a phone number already exists in the database.
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool IsPhoneExists(string phone)
        {
            using var conn = DatabaseHelper.GetConnection();
            string query = "SELECT COUNT(*) FROM users WHERE phone = @phone";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@phone", phone);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        /// <summary>
        /// Retrieves a user by their email address from the database.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetUserByEmail(string email)
        {
            const string query = "SELECT * FROM users WHERE email = @email LIMIT 1";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@email", email);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        FirstName = reader["first_name"].ToString(),
                        Email = reader["email"].ToString(),
                        Phone = reader["phone"]?.ToString(),
                        PasswordHash = reader["password_hash"].ToString(),
                        UserType = (UserType)Convert.ToInt32(reader["user_type"]),
                        CustomerNumber = reader["customer_number"]?.ToString()
                    };
                }
            }

            return null;
        }


        public bool ToggleUserStatus(string customerNumber)
        {
            string query = "UPDATE users SET is_active = IF(is_active = 1, 0, 1) WHERE customer_number = @customerNumber";

            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@customerNumber", customerNumber);
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

    }
}
