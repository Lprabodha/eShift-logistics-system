using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Interface
{
    public interface IAssistantRepository
    {

        /// <summary>
        /// Adds a new assistant to the repository.
        /// </summary>
        /// <param name="assistant">The assistant to add.</param>
        void AddAssistant(Assistant assistant);
        /// <summary>
        /// Updates an existing assistant in the repository.
        /// </summary>
        /// <param name="assistant">The assistant to update.</param>
        void UpdateAssistant(Assistant assistant);
        /// <summary>
        /// Deletes an assistant from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the assistant to delete.</param>
        /// <returns>True if the deletion was successful, otherwise false.</returns>
        bool DeleteAssistant(int id);
        /// <summary>
        /// Retrieves all assistants from the repository.
        /// </summary>
        /// <returns>A list of all assistants.</returns>
        List<Assistant> GetAllAssistants();
        /// <summary>
        /// Retrieves an assistant by its ID.
        /// </summary>
        /// <param name="id">The ID of the assistant to retrieve.</param>
        /// <returns>The assistant with the specified ID, or null if not found.</returns>
        Assistant GetAssistantById(int id);

        /// <summary>
        /// Checks if a phone number already exists in the repository, excluding a specific assistant ID.
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="assitantIdToExclude"></param>
        /// <returns></returns>
        bool IsPhoneNumberExists(string phoneNumber, int assitantIdToExclude);

        List<Assistant> GetAvailableAssistants(int? currentAssistantId = null);
    }
}
