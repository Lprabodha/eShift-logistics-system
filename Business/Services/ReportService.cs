using eShift_Logistics_System.Business.Interface;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using eShift_Logistics_System.Repository.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Business.Services
{
    public class ReportService : IReportService
    {

        private readonly IReportRepository _reportService;

        public ReportService(IReportRepository reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Generates a summary report of jobs within a specified date range, filtered by job status and user ID if provided.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="status"></param>
        /// <param name="userId"></param>
        /// <returns></returns>

        public async Task<DataTable> GetJobSummaryReportAsync(DateTime startDate, DateTime endDate, JobStatus? status, int? userId)
        {
            return await _reportService.GetJobSummaryReportAsync(startDate, endDate, status, userId);
        }

        /// <summary>
        /// Generates a revenue report for the specified date range, summarizing total revenue and other financial metrics.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<DataTable> GetRevenueReportAsync(DateTime startDate, DateTime endDate)
        {
            return await _reportService.GetRevenueReportAsync(startDate, endDate);
        }

        /// <summary>
        /// Generates a report on the utilization of transport units within a specified date range, optionally filtered by transport unit ID.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="transportUnitId"></param>
        /// <returns></returns>
        public async Task<DataTable> GetTransportUnitUtilizationReportAsync(DateTime startDate, DateTime endDate, int? transportUnitId)
        {
            return await _reportService.GetTransportUnitUtilizationReportAsync(startDate, endDate, transportUnitId);
        }

        /// <summary>
        /// Generates a report on customer activity within a specified date range, optionally filtered by customer ID.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<DataTable> GetCustomerActivityReportAsync(DateTime startDate, DateTime endDate, int? customerId)
        {
            return await _reportService.GetCustomerActivityReportAsync(startDate, endDate, customerId);
        }

        /// <summary>
        /// Generates a report on driver activity within a specified date range, optionally filtered by driver ID.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="driverId"></param>
        /// <returns></returns>
        public async Task<DataTable> GetDriverActivityReportAsync(DateTime startDate, DateTime endDate, int? driverId)
        {
            return await _reportService.GetDriverActivityReportAsync(startDate, endDate, driverId);
        }

        /// <summary>
        /// Generates a report on assistant activity within a specified date range, optionally filtered by assistant ID.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="assistantId"></param>
        /// <returns></returns>
        public async Task<DataTable> GetAssistantActivityReportAsync(DateTime startDate, DateTime endDate, int? assistantId)
        {
            return await _reportService.GetAssistantActivityReportAsync(startDate, endDate, assistantId);
        }

        /// <summary>
        /// Generates a report that provides an overall breakdown of job statuses, including counts and percentages for each status.
        /// </summary>
        /// <returns></returns>
        public async Task<DataTable> GetOverallJobStatusBreakdownAsync()
        {
            return await _reportService.GetOverallJobStatusBreakdownAsync();
        }

        /// <summary>
        /// Generates a report of cancelled jobs within a specified date range.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<DataTable> GetCancelledJobsReportAsync(DateTime startDate, DateTime endDate)
        {
            return await _reportService.GetCancelledJobsReportAsync(startDate, endDate);
        }

        /// <summary>
        /// Generates a report of users in the system, optionally filtered by user type.
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>
        public async Task<DataTable> GetUserListReportAsync(UserType? userType = null)
        {
            return await _reportService.GetUserListReportAsync(userType);
        }

    }
}
