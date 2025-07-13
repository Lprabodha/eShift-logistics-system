using eShift_Logistics_System.Helpers;
using eShift_Logistics_System.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Service
{
    public class JobStatusRepository : IJobStatusRepository
    {

        public void AddLogJobStatus(int jobId, string status, int? updatedBy, string note = "")
        {
            string query = @"
        INSERT INTO job_status_logs (job_id, status, updated_by, note)
        VALUES (@job_id, @status, @updated_by, @note);";

            DatabaseHelper.ExecuteNonQuery(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@job_id", jobId);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@updated_by", updatedBy.HasValue ? (object)updatedBy.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@note", string.IsNullOrWhiteSpace(note) ? DBNull.Value : note);
            });
        }
    }
}
