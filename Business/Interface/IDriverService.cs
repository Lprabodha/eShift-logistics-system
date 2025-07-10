using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Interface
{
    public interface IDriverService
    {
        /// <summary>
        /// Adds a new driver to the service.
        /// </summary>
        /// <param name="driver"></param>
        void AddDriver(Driver driver);

        /// <summary>
        /// Updates an existing driver in the service.
        /// </summary>
        /// <param name="driver"></param>
        void UpdateDriver(Driver driver);

        /// <summary>
        /// Deletes a driver from the service by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteDriver(int id);

        /// <summary>
        /// Retrieves all drivers from the service.
        /// </summary>
        /// <returns></returns>
        List<Driver> GetAllDrivers();

        /// <summary>
        /// Retrieves a driver by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Driver GetDriverById(int id);

        List<Driver> GetAvailableDrivers(int? currentDrivertId = null);
    }
}
