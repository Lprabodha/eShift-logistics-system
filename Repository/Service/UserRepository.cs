using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Service
{
    public class UserRepository: IUserRepository
    {
        
        public void AddUser(User user)
        {
            // Implementation for adding a user
        }

        void IUserRepository.AddUser(User user)
        {
            throw new NotImplementedException();
        }

        void IUserRepository.DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        User IUserRepository.GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        void IUserRepository.UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        List<User> IUserRepository.GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
