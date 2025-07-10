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
        /// <summary>
        /// Adds a new assistant to the service.
        /// </summary>
        /// <param name="assistant"></param>
        void AddAssistant(Assistant assistant);

        /// <summary>
        /// Updates an existing assistant in the service.
        /// </summary>
        /// <param name="assistant"></param>
        void UpdateAssistant(Assistant assistant);

        /// <summary>
        /// Deletes an assistant from the service by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteAssistant(int id);

        /// <summary>
        /// Retrieves all assistants from the service.
        /// </summary>
        /// <returns></returns>
        List<Assistant> GetAllAssistants();

        /// <summary>
        /// Retrieves an assistant by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Assistant GetAssistantById(int id);

        List<Assistant> GetAvailableAssistants(int? currentAssistantId = null);
    }
}
