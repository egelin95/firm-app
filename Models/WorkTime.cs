
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class WorkTime
    {
        [Key]
        public Guid WorkTimeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } = null!;
        public Guid EmployeeId { get; set; }

        // public JobTitle JobTitle { get; set; } = null!;
        // public Guid JobTitleId { get; set; }

        public DateTime StartingDate { get; set; }

        public DateTime? EndingDate { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? Comment { get; set; }
    }
}
