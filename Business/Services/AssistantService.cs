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
    public class AssistantService : IAssistantService
    {
        private readonly IAssistantRepository _assistantService;

        public AssistantService(IAssistantRepository assistantService)
        {
            _assistantService = assistantService;
        }

        public void AddAssistant(Assistant assistant)
        {

            _assistantService.AddAssistant(assistant);
        }
        public void UpdateAssistant(Assistant assistant)
        {

            _assistantService.UpdateAssistant(assistant);
        }
        public bool DeleteAssistant(int id)
        {

            return _assistantService.DeleteAssistant(id);
        }
        public List<Assistant> GetAllAssistants()
        {

            return _assistantService.GetAllAssistants();
        }
        public Assistant GetAssistantById(int id)
        {

            return _assistantService.GetAssistantById(id);
        }


        public List<Assistant> GetAvailableAssistants(int? currentAssistantId = null)
        {
            return _assistantService.GetAvailableAssistants(currentAssistantId);
        }
    }
}
