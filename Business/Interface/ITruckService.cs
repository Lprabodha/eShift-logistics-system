using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Interface
{
   public interface ITruckService
    {

        void AddTruck(Truck truck);
        void UpdateTruck(Truck truck);
        bool DeleteTruck(int id);
        List<Truck> GetAllTrucks();

    }
}
