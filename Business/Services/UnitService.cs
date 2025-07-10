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

        private readonly IUnitRepository _unitService;
        public UnitService(IUnitRepository unitRepository)
        {

            _unitService = unitRepository;

        }

        public void AddUnit(TransportUnit unit)
        {
            _unitService.AddUnit(unit);
        }

        public void UpdateUnit(TransportUnit unit)
        {
            _unitService.UpdateUnit(unit);
        }

        public bool DeleteUnit(int id)
        {
            return _unitService.DeleteUnit(id);
        }

        public List<TransportUnit> GetAllUnits()
        {
            return _unitService.GetAllUnits();
        }

        public TransportUnit GetUnitById(int id)
        {
            return _unitService.GetUnitById(id);
        }

        public int GetTotalUnitCount()
        {
            return _unitService.GetTotalUnitCount();
        }

    }

}