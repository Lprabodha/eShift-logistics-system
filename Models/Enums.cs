using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Models
{

    /// <summary>
    /// Enumeration representing the status of a truck.
    /// </summary>
    public enum TruckStatus
    {
        Available = 1,
        OnJob = 2,
        InMaintenance = 3,
        OutOfService = 4
    }

    /// <summary>
    /// Enumeration representing the status of a driver.
    /// </summary>
    public enum DriverStatus
    {
        Available = 1,
        Assigned = 2,
        OnLeave = 3
    }

    /// <summary>
    /// Enumeration representing the status of an assistant.
    /// </summary>
    public enum AssistantStatus
    {
        Available = 1,
        Assigned = 2,
        Unavailable = 3
    }

    /// <summary>
    /// Enumeration representing the status of a transport unit.
    /// </summary>
    public enum TransportUnitStatus
    {
        Free = 1,
        OnJob = 2,
        Assigned = 3
    }

    /// <summary>
    /// Enumeration representing the status of a job.
    /// </summary>
    public enum JobStatus
    {
        PendingConfirmation = 1,
        Accepted = 2,
        Declined = 3,
        Ongoing = 4,
        Completed = 5,
        Cancelled = 6
    }

    /// <summary>
    /// Enumeration representing the type of user in the system.
    /// </summary>
    public enum UserType
    {
        Customer = 1,
        Admin = 2
    }
    
}
