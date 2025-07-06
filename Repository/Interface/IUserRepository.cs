using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Interface
{
    internal interface IUserRepository
    {
        void AddUser(User user);
        User GetUserById(int id);

        void UpdateUser(User user);

        void DeleteUser(int id);

        List<User> GetAllUsers();
    }
}
