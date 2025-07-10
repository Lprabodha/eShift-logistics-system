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
        /// <summary>
        /// Service class for managing truck operations.
        /// </summary>
        private readonly ITruckRepository _truckService;

        /// <summary>
        /// Constructor for TruckService.
        /// </summary>
        /// <param name="truckService"></param>
        public TruckService(ITruckRepository truckService)
        {
            _truckService = truckService;
        }

        /// <summary>
        /// Adds a new truck to the system.
        /// </summary>
        /// <param name="truck"></param>
        public void AddTruck(Truck truck)
        {
            _truckService.AddTruck(truck);
        }

        /// <summary>
        /// Updates an existing truck in the system.
        /// </summary>
        /// <param name="truck"></param>
        public void UpdateTruck(Truck truck)
        {
            _truckService.UpdateTruck(truck);
        }

        /// <summary>
        /// Deletes a truck from the system by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteTruck(int id)
        {
            return _truckService.DeleteTruck(id);

        }

        /// <summary>
        /// Retrieves all trucks from the system.
        /// </summary>
        /// <returns></returns>
        public List<Truck> GetAllTrucks()
        {
            return _truckService.GetAllTrucks() ?? new List<Truck>();
        }

        /// <summary>
        /// Checks if a truck number already exists in the system, excluding a specific truck ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Truck GetTruckById(int id)
        {
            return _truckService.GetTruckById(id);
        }

        public List<Truck> GetAvailableTrucks(int? currentTruckId = null)
        {
            return _truckService.GetAvailableTrucks(currentTruckId);
        }

    }
}
