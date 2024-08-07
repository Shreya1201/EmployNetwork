using EmployNet.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EmployNet.Data
{
    // ApplicationUser class extending IdentityUser to include additional properties
    public class ApplicationUser : IdentityUser
    {
        // Additional properties for the user
        public string? Name { get; set; }
        public string? ProfilePicture { get; set; }

        // Navigation property for leave requests created by the user
        public ICollection<LeaveRequest> LeaveRequests { get; set; }

        // Navigation property for leave approvals handled by the user (as a manager)
        public ICollection<LeaveApproval> LeaveApprovals { get; set; }
    }
}
