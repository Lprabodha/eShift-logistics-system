using eShift_Logistics_System.Business.Interface;
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
   public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckService;

        public TruckService(ITruckRepository truckService)
        {
            _truckService = truckService;
        }

        public void AddTruck(Truck truck)
        {
            _truckService.AddTruck(truck);
        }

        public void UpdateTruck(Truck truck)
        {
            _truckService.UpdateTruck(truck);
        }

        public bool DeleteTruck(int id)
        {
            // Implementation for deleting a truck
            throw new NotImplementedException();
        }

        public List<Truck> GetAllTrucks()
        {
            return _truckService.GetAllTrucks() ?? new List<Truck>();
        }

        public Truck GetTruckById(int id)
        {
            return _truckService.GetTruckById(id);
        }

    }
}
