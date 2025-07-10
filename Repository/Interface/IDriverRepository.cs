using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Interface
{
    public interface IDriverRepository
    {

        /// <summary>
        /// Adds a new driver to the repository.
        /// </summary>
        /// <param name="driver"></param>
        void AddDriver(Driver driver);

        /// <summary>
        /// Updates an existing driver in the repository.
        /// </summary>
        /// <param name="driver"></param>
        void UpdateDriver(Driver driver);

        /// <summary>
        /// Deletes a driver from the repository by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteDriver(int id);

        /// <summary>
        /// Retrieves all drivers from the repository.
        /// </summary>
        /// <returns></returns>
        List<Driver> GetAllDrivers();

        /// <summary>
        /// Retrieves a driver by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Driver GetDriverById(int id);

        /// <summary>
        ///     
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="driverIdToExclude"></param>
        /// <returns></returns>
        bool IsPhoneNumberExists(string phoneNumber, int driverIdToExclude);

        /// <summary>
        /// Checks if a license number already exists in the repository, excluding a specific driver ID.
        /// </summary>
        /// <param name="licenseNumber"></param>
        /// <param name="driverIdToExclude"></param>
        /// <returns></returns>
        bool IsLicenseNumberExists(string licenseNumber, int driverIdToExclude);

        List<Driver> GetAvailableDrivers(int? currentDrivertId = null);
    }
}
