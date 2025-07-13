using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Interface
{
    public interface IUnitService
    {
        /// <summary>
        /// Adds a new unit to the service.
        /// </summary>
        /// <param name="unit"></param>
        void AddUnit(TransportUnit unit);
        /// <summary>
        /// Updates an existing unit in the service.
        /// </summary>
        /// <param name="unit"></param>
        void UpdateUnit(TransportUnit unit);
        /// <summary>
        /// Deletes a unit from the service by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteUnit(int id);
        /// <summary>
        /// Retrieves all units from the service.
        /// </summary>
        /// <returns></returns>
        List<TransportUnit> GetAllUnits();
        /// <summary>
        /// Retrieves a unit by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TransportUnit GetUnitById(int id);

        /// <summary>
        /// Retrieves the last unit ID from the service.
        /// </summary>
        /// <returns></returns>
        int GetLastUnitId();

        /// <summary>
        /// Retrieves all available transport units that are not currently assigned to any job.
        /// </summary>
        /// <returns></returns>
        List<TransportUnit> GetAvailableUnits(int? currentUnitId = null);
    }
}
