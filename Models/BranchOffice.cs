
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class BranchOffice
    {
        [Key]
        public Guid BranchOfficeId { get; set; }

        [ForeignKey("CompanyId")]
        [Required]
        public Company Company { get; set; } = null!;

        public Guid CompanyId { get; set; }

        public ICollection<Department> Departments { get; } = new List<Department>();

        public int RegistryNumber { get; set; }

        [Unicode(false)]
        [MaxLength(20)]
        public string Name { get; set; }

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
    }
}
