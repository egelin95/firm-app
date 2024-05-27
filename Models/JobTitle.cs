
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class JobTitle
    {
        [Key]
        public Guid JobTitleId { get; set; }

        [Unicode(false)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Unicode(false)]
        [MaxLength(30)]
        public string? Description { get; set; }

        public decimal SalaryLevel { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? Comment { get; set; }
    }
}
