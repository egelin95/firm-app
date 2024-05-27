
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class Department
    {
        [Key]
        public Guid DepartmentId { get; set; }

        [ForeignKey("BranchOfficeId")]
        [Required]
        public BranchOffice BranchOffice { get; set; } = null!;

        public Guid BranchOfficeId { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? Address { get; set; }

        [Unicode(false)]
        [MaxLength(20)]
        public string? ContactPerson { get; set; }

        public int? ContactPhoneNumber { get; set; }

        [Unicode(false)]
        [MaxLength(30)]
        public string? ContactEmail { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? Comment { get; set; }

        public ICollection<Employee> Employees { get; } = new List<Employee>();
    }
}
