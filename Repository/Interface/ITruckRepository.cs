using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Interface
{
    public interface ITruckRepository
    {
        /// <summary>
        /// Repository interface for managing truck operations.
        /// </summary>
        /// <param name="truck"></param>
        void AddTruck(Truck truck);

        /// <summary>
        /// Updates an existing truck in the system.
        /// </summary>
        /// <param name="truck"></param>
        void UpdateTruck(Truck truck);

        /// <summary>
        /// Deletes a truck from the system by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteTruck(int id);

        /// <summary>
        /// Retrieves all trucks from the system.
        /// </summary>
        /// <returns></returns>
        List<Truck> GetAllTrucks();

        /// <summary>
        /// Checks if a truck number already exists in the system, excluding a specific truck ID.
        /// </summary>
        /// <param name="truckNumber"></param>
        /// <param name="truckIdToExclude"></param>
        /// <returns></returns>
        bool IsTruckNumberExists(string truckNumber, int truckIdToExclude);

        /// <summary>
        /// Retrieves a truck by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Truck GetTruckById(int id);

        /// <summary>
        /// Checks if a license plate already exists in the system, excluding a specific truck ID.
        /// </summary>
        /// <param name="licensePlate"></param>
        /// <param name="truckIdToExclude"></param>
        /// <returns></returns>
        bool IsLicensePlateExists(string licensePlate, int truckIdToExclude);

        /// <summary>
        /// Retrieves a list of available trucks, optionally excluding a specific truck ID.
        /// </summary>
        /// <param name="currentTruckId"></param>
        /// <returns></returns>

        List<Truck> GetAvailableTrucks(int? currentTruckId = null);
    }
}
