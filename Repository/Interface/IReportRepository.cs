using eShift_Logistics_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Interface
{
    public interface IReportRepository
    {
        /// <summary>
        /// Generates a summary report of jobs within a specified date range, filtered by job status and user ID if provided.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="status"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DataTable> GetJobSummaryReportAsync(DateTime startDate, DateTime endDate, JobStatus? status, int? userId);

        /// <summary>
        /// Generates a revenue report for the specified date range, summarizing total revenue and other financial metrics.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<DataTable> GetRevenueReportAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Generates a report on the utilization of transport units within a specified date range, optionally filtered by transport unit ID.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="transportUnitId"></param>
        /// <returns></returns>
        Task<DataTable> GetTransportUnitUtilizationReportAsync(DateTime startDate, DateTime endDate, int? transportUnitId);

        /// <summary>
        /// Generates a report on customer activity within a specified date range, optionally filtered by customer ID.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<DataTable> GetCustomerActivityReportAsync(DateTime startDate, DateTime endDate, int? customerId);

        /// <summary>
        /// Generates a report on driver activity within a specified date range, optionally filtered by driver ID.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="driverId"></param>
        /// <returns></returns>
        Task<DataTable> GetDriverActivityReportAsync(DateTime startDate, DateTime endDate, int? driverId);

        /// <summary>
        /// Generates a report on assistant activity within a specified date range, optionally filtered by assistant ID.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="assistantId"></param>
        /// <returns></returns>
        Task<DataTable> GetAssistantActivityReportAsync(DateTime startDate, DateTime endDate, int? assistantId);

        /// <summary>
        /// Generates a breakdown report of overall job statuses, summarizing the distribution of jobs across different statuses.
        /// </summary>
        /// <returns></returns>
        Task<DataTable> GetOverallJobStatusBreakdownAsync();

        /// <summary>
        /// Generates a report listing all jobs that were cancelled within a specified date range.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<DataTable> GetCancelledJobsReportAsync(DateTime startDate, DateTime endDate);

        /// <summary>
        /// Generates a report listing all users in the system, optionally filtered by user type (e.g., admin, driver, assistant).
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        Task<DataTable> GetUserListReportAsync(UserType? userType = null);

    }
}
