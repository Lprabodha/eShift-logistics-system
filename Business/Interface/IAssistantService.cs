using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Interface
{
   public  interface IAssistantService
    {
        void AddAssistant(Assistant assistant);
        void UpdateAssistant(Assistant assistant);
        bool DeleteAssistant(int id);
        List<Assistant> GetAllAssistants();
        Assistant GetAssistantById(int id);
    }
}
