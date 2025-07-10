using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Services
{
    public class DriverService : IDriverService
    {
        /// <summary>
        /// Represents the driver repository used by the service.
        /// </summary>
        private readonly IDriverRepository   _driverService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverService"/> class.
        /// </summary>
        /// <param name="driverService"></param>
        public DriverService(IDriverRepository driverService)
        {
            _driverService = driverService;
        }

        /// <summary>
        /// Adds a new driver to the service.
        /// </summary>
        /// <param name="driver"></param>
        public void AddDriver(Driver driver)
        {
            _driverService.AddDriver(driver);
        }

        /// <summary>
        /// Updates an existing driver in the service.
        /// </summary>
        /// <param name="driver"></param>
        public void UpdateDriver(Driver driver)
        {
            _driverService.UpdateDriver(driver);
        }

        /// <summary>
        /// Deletes a driver from the service by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteDriver(int id)
        {
            return _driverService.DeleteDriver(id);
        }

        /// <summary>
        /// Retrieves all drivers from the service.
        /// </summary>
        /// <returns></returns>
        public List<Driver> GetAllDrivers()
        {
            return _driverService.GetAllDrivers();
        }

        /// <summary>
        /// Retrieves a driver by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Driver GetDriverById(int id)
        {
            return _driverService.GetDriverById(id);
        }


        public List<Driver> GetAvailableDrivers(int? currentDrivertId = null)
        {
            return _driverService.GetAvailableDrivers(currentDrivertId);
        }
    }
}
