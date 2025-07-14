using eShift_Logistics_System.Helpers;
using eShift_Logistics_System.Models;
using eShift_Logistics_System.Repository.Interface;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Repository.Service
{
    public class ReportRepository: IReportRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="status"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
            public async Task<DataTable> GetJobSummaryReportAsync(DateTime startDate, DateTime endDate, JobStatus? status, int? userId)
            {
                string query = @"
                SELECT
                    j.job_number AS 'Job Number',
                    u.first_name AS 'Customer Name',
                    j.pickup_location AS 'Pickup Location',
                    j.delivery_location AS 'Delivery Location',
                    j.requested_date AS 'Requested Date',
                    j.status AS 'Status',
                    j.estimated_cost AS 'Estimated Cost'
                FROM jobs j
                INNER JOIN users u ON j.customer_id = u.id
                WHERE j.requested_date BETWEEN @startDate AND @endDate";

                if (status.HasValue)
                {
                    query += " AND j.status = @status";
                }
                if (userId.HasValue && userId.Value != 0) 
                {
                    query += " AND j.customer_id = @userId";
                }
                query += " ORDER BY j.requested_date DESC;";

                var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@startDate", startDate),
                new MySqlParameter("@endDate", endDate)
            };
                if (status.HasValue) parameters.Add(new MySqlParameter("@status", (int)status.Value));
                if (userId.HasValue && userId.Value != 0) parameters.Add(new MySqlParameter("@userId", userId.Value));

                return await DatabaseHelper.ExecuteReaderAsyncToDataTable(query, parameters.ToArray());
            }

        /// <summary>
        /// Generates a revenue report for the specified date range, summarizing total revenue and other financial metrics.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<DataTable> GetRevenueReportAsync(DateTime startDate, DateTime endDate)
            {
                string query = @"
                SELECT
                    DATE_FORMAT(j.completion_date, '%Y-%m') AS 'Month',
                    SUM(j.actual_cost) AS 'TotalRevenue'
                FROM jobs j
                WHERE j.status = @completedStatus AND j.completion_date BETWEEN @startDate AND @endDate
                GROUP BY DATE_FORMAT(j.completion_date, '%Y-%m')
                ORDER BY DATE_FORMAT(j.completion_date, '%Y-%m');";

                var parameters = new MySqlParameter[]
                {
                new MySqlParameter("@startDate", startDate),
                new MySqlParameter("@endDate", endDate),
                new MySqlParameter("@completedStatus", (int)JobStatus.Completed)
                };
                return await DatabaseHelper.ExecuteReaderAsyncToDataTable(query, parameters);
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
                    string query = @"
                SELECT
                    tu.unit_number AS 'Unit Number',
                    d.name AS 'Driver',
                    t.license_plate AS 'Truck',
                    COUNT(j.id) AS 'Jobs Completed',
                    SUM(j.actual_cost) AS 'Revenue Generated'
                FROM transport_units tu
                INNER JOIN jobs j ON tu.id = j.transport_unit_id
                INNER JOIN drivers d ON tu.driver_id = d.id
                INNER JOIN trucks t ON tu.truck_id = t.id
                WHERE j.completion_date BETWEEN @startDate AND @endDate AND j.status = @completedStatus";

                    if (transportUnitId.HasValue && transportUnitId.Value != 0)
                    {
                        query += " AND tu.id = @transportUnitId";
                    }
                    query += " GROUP BY tu.unit_number, d.name, t.license_plate ORDER BY 'Jobs Completed' DESC;";

                    var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@startDate", startDate),
                new MySqlParameter("@endDate", endDate),
                new MySqlParameter("@completedStatus", (int)JobStatus.Completed)
            };
            if (transportUnitId.HasValue && transportUnitId.Value != 0) parameters.Add(new MySqlParameter("@transportUnitId", transportUnitId.Value));

            return await DatabaseHelper.ExecuteReaderAsyncToDataTable(query, parameters.ToArray());
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
                string query = @"
                SELECT
                    u.first_name AS 'Customer Name',
                    u.email AS 'Email',
                    COUNT(j.id) AS 'JobCount',
                    SUM(j.estimated_cost) AS 'Total Estimated Cost'
                FROM users u
                INNER JOIN jobs j ON u.id = j.customer_id
                WHERE j.requested_date BETWEEN @startDate AND @endDate";

                if (customerId.HasValue && customerId.Value != 0)
                {
                    query += " AND u.id = @customerId";
                }
                query += " GROUP BY u.first_name, u.email ORDER BY JobCount DESC;";

                var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@startDate", startDate),
                new MySqlParameter("@endDate", endDate)
            };
                if (customerId.HasValue && customerId.Value != 0) parameters.Add(new MySqlParameter("@customerId", customerId.Value));

                return await DatabaseHelper.ExecuteReaderAsyncToDataTable(query, parameters.ToArray());
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
                string query = @"
                SELECT
                    d.name AS 'Driver Name',
                    d.license_number AS 'License Number',
                    COUNT(j.id) AS 'Jobs Assigned',
                    SUM(j.actual_cost) AS 'Revenue Handled'
                FROM drivers d
                INNER JOIN transport_units tu ON d.id = tu.driver_id
                INNER JOIN jobs j ON tu.id = j.transport_unit_id
                WHERE j.completion_date BETWEEN @startDate AND @endDate AND j.status = @completedStatus";

                if (driverId.HasValue && driverId.Value != 0)
                {
                    query += " AND d.id = @driverId";
                }
                query += " GROUP BY d.name, d.license_number ORDER BY 'Jobs Assigned' DESC;";

                var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@startDate", startDate),
                new MySqlParameter("@endDate", endDate),
                new MySqlParameter("@completedStatus", (int)JobStatus.Completed)
            };
                if (driverId.HasValue && driverId.Value != 0) parameters.Add(new MySqlParameter("@driverId", driverId.Value));

                return await DatabaseHelper.ExecuteReaderAsyncToDataTable(query, parameters.ToArray());
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
                string query = @"
                SELECT
                    a.name AS 'Assistant Name',
                    a.phone AS 'Phone',
                    COUNT(j.id) AS 'Jobs Assisted'
                FROM assistants a
                INNER JOIN transport_units tu ON a.id = tu.assistant_id
                INNER JOIN jobs j ON tu.id = j.transport_unit_id
                WHERE j.completion_date BETWEEN @startDate AND @endDate AND j.status = @completedStatus";

                if (assistantId.HasValue && assistantId.Value != 0)
                {
                    query += " AND a.id = @assistantId";
                }
                query += " GROUP BY a.name, a.phone ORDER BY 'Jobs Assisted' DESC;";

                var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@startDate", startDate),
                new MySqlParameter("@endDate", endDate),
                new MySqlParameter("@completedStatus", (int)JobStatus.Completed)
            };
                if (assistantId.HasValue && assistantId.Value != 0) parameters.Add(new MySqlParameter("@assistantId", assistantId.Value));

                return await DatabaseHelper.ExecuteReaderAsyncToDataTable(query, parameters.ToArray());
            }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
            public async Task<DataTable> GetOverallJobStatusBreakdownAsync()
            {
                string query = @"
                SELECT
                    CASE j.status
                        WHEN 1 THEN 'Pending Confirmation'
                        WHEN 2 THEN 'Accepted'
                        WHEN 3 THEN 'Declined'
                        WHEN 4 THEN 'Ongoing'
                        WHEN 5 THEN 'Completed'
                        WHEN 6 THEN 'Cancelled'
                        ELSE 'Unknown'
                    END AS 'StatusName',
                    COUNT(j.id) AS 'JobCount',
                    (COUNT(j.id) * 100.0 / (SELECT COUNT(*) FROM jobs)) AS 'Percentage'
                FROM jobs j
                GROUP BY j.status
                ORDER BY JobCount DESC;";

                return await DatabaseHelper.ExecuteReaderAsyncToDataTable(query);
            }

        /// <summary>
        /// Generates a report of cancelled jobs within a specified date range, including job number, customer name, pickup and delivery locations, requested date, cancellation date, and reason for cancellation.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<DataTable> GetCancelledJobsReportAsync(DateTime startDate, DateTime endDate)
            {
                string query = @"
                SELECT
                    j.job_number AS 'Job Number',
                    u.first_name AS 'Customer Name',
                    j.pickup_location AS 'Pickup Location',
                    j.delivery_location AS 'Delivery Location',
                    j.requested_date AS 'Requested Date',
                    j.completion_date AS 'Cancellation Date',
                    j.notes AS 'Reason'
                FROM jobs j
                INNER JOIN users u ON j.customer_id = u.id
                WHERE j.status = @cancelledStatus AND j.completion_date BETWEEN @startDate AND @endDate
                ORDER BY j.completion_date DESC;";

                var parameters = new MySqlParameter[]
                {
                new MySqlParameter("@startDate", startDate),
                new MySqlParameter("@endDate", endDate),
                new MySqlParameter("@cancelledStatus", (int)JobStatus.Cancelled)
                };
                return await DatabaseHelper.ExecuteReaderAsyncToDataTable(query, parameters);
            }

        /// <summary>
        /// Generates a report listing all users in the system, including their ID, name, email, phone, address, user type, customer number (if applicable), member since date, and active status.
        /// </summary>
        /// <param name="userType"></param>
        /// <returns></returns>

        public async Task<DataTable> GetUserListReportAsync(UserType? userType = null)
            {
                string query = @"
                SELECT
                    id AS 'User ID',
                    first_name AS 'First Name',
                    last_name AS 'Last Name',
                    email AS 'Email',
                    phone AS 'Phone',
                    address AS 'Address',
                    CASE user_type
                        WHEN 1 THEN 'Customer'
                        WHEN 2 THEN 'Admin'
                        ELSE 'Unknown'
                    END AS 'User Type',
                    customer_number AS 'Customer Number',
                    created_date AS 'Member Since',
                    is_active AS 'Is Active'
                FROM users";

                if (userType.HasValue)
                {
                    query += " WHERE user_type = @userType";
                }
                query += " ORDER BY first_name ASC;";

                var parameters = new List<MySqlParameter>();
                if (userType.HasValue) parameters.Add(new MySqlParameter("@userType", (int)userType.Value));

                return await DatabaseHelper.ExecuteReaderAsyncToDataTable(query, parameters.ToArray());
            }
        }

 }

