
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class Company
    {
        [Key]
        public Guid CompanyId { get; set; }

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

        public ICollection<BranchOffice> BranchOffices { get; } = new List<BranchOffice>();
    }
}
