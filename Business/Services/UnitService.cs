using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using eShift_Logistics_System.Repository.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Services
{
    public class UnitService : IUnitService
    {
        /// <summary>
        /// Service for managing transport units in the logistics system.
        /// </summary>
        private readonly IUnitRepository _unitService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitService"/> class.
        /// </summary>
        /// <param name="unitRepository"></param>
        public UnitService(IUnitRepository unitRepository)
        {

            _unitService = unitRepository;

        }

        /// <summary>
        /// Adds a new transport unit to the system.
        /// </summary>
        /// <param name="unit"></param>
        public void AddUnit(TransportUnit unit)
        {
            _unitService.AddUnit(unit);
        }

        /// <summary>
        /// Updates an existing transport unit in the system.
        /// </summary>
        /// <param name="unit"></param>

        public void UpdateUnit(TransportUnit unit)
        {
            _unitService.UpdateUnit(unit);
        }

        /// <summary>
        /// Deletes a transport unit from the system by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public bool DeleteUnit(int id)
        {
            return _unitService.DeleteUnit(id);
        }

        /// <summary>
        /// Retrieves all transport units from the system.
        /// </summary>
        /// <returns></returns>
        public List<TransportUnit> GetAllUnits()
        {
            return _unitService.GetAllUnits();
        }

        /// <summary>
        /// Retrieves a transport unit by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public TransportUnit GetUnitById(int id)
        {
            return _unitService.GetUnitById(id);
        }

        /// <summary>
        /// Retrieves the last transport unit ID from the system.
        /// </summary>
        /// <returns></returns>

        public int GetLastUnitId()
        {
            return _unitService.GetLastUnitId();
        }


        /// <summary>
        /// Retrieves all available transport units that are not currently assigned to any job.
        /// </summary>
        /// <returns></returns>
        public List<TransportUnit> GetAvailableUnits(int? currentUnitId = null)
        {
            return _unitService.GetAvailableUnits(currentUnitId);
        }

    }

}