
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class SickLeave
    {
        [Key]
        public Guid SickLeaveId { get; set; }

        [ForeignKey("EmployeeId")]
        [Required]
        public Employee Employee { get; set; } = null!;
        public Guid EmployeeId { get; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? Comment { get; set; }
    }
}
