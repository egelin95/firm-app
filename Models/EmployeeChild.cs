
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class EmployeeChild
    {
        [Key]
        public Guid EmployeeChildId { get; set; }

        [ForeignKey("EmployeeId")]
        [Required]
        public Employee Employee { get; set; } = null!;
        public Guid EmployeeId { get; set; }

        [Unicode(false)]
        [MaxLength(20)]
        public string? FirstName { get; set; }

        [Unicode(false)]
        [MaxLength(20)]
        public string? LastName { get; set; }

        public int Age { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? Comment { get; set; }
    }
}
