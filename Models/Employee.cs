
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class Employee
    {
        [Key]
        public Guid EmployeeId { get; set; }

        [Unicode(false)]
        [MaxLength(20)]
        public string? FirstName { get; set; }

        [Unicode(false)]
        [MaxLength(20)]
        public string? LastName { get; set; }


        public int PersonalIdentificationNumber { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? ContactAddress { get; set; }

        public int? ContactPhoneNumber { get; set; }

        [Unicode(false)]
        [MaxLength(30)]
        public string? ContactEmail { get; set; }

        public DateTime AtWorkSince { get; set; }

        public DateTime? AtWorkUntil { get; set; }

        [ForeignKey("JobTitleId")]
        [Required]
        public JobTitle JobTitle { get; set; } = null!;
        public Guid JobTitleId { get; set; }

        public decimal Salary { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? Comment { get; set; }

        public Department Department { get; set; } = null!;

        [ForeignKey("AccessLevelId")]
        public ICollection<AccessLevel> AccessLevels { get; } = new List<AccessLevel>();

        public ICollection<Vacation> Vacations { get; } = new List<Vacation>();

        public ICollection<SickLeave> SickLeaves { get; } = new List<SickLeave>();

        public ICollection<HealthCheck> HealthChecks { get; } = new List<HealthCheck>();

        public ICollection<EmployeeChild> Children { get; } = new List<EmployeeChild>();

        public ICollection<Request> Requests { get; } = new List<Request>();

        public ICollection<WorkTime> WorkTimes { get; } = new List<WorkTime>();

        public ICollection<BorrowedItem> BorrowedItems { get; } = new List<BorrowedItem>();
    }
}
