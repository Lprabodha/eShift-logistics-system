using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShift_Logistics_System.Models
{
    /// <summary>
    /// Represents a user in the logistics system, which can be a customer, admin
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        public UserType UserType { get; set; } = UserType.Customer;

        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? CustomerNumber { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public string FullName => $"{FirstName} {LastName}";

    }
}
