using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Interface
{
    public interface IUnitRepository
    {
        /// <summary>
        /// Adds a new transport unit to the repository.
        /// </summary>
        /// <param name="unit"></param>
        void AddUnit(TransportUnit unit);

        /// <summary>
        /// Updates an existing transport unit in the repository.
        /// </summary>
        /// <param name="unit"></param>
        void UpdateUnit(TransportUnit unit);

        /// <summary>
        /// Deletes a transport unit from the repository by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteUnit(int id);

        /// <summary>
        /// Retrieves all transport units from the repository.
        /// </summary>
        /// <returns></returns>
        List<TransportUnit> GetAllUnits();

        /// <summary>
        /// Retrieves a transport unit by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TransportUnit GetUnitById(int id);

        /// <summary>
        /// Retrieves the last transport unit ID from the repository.
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
