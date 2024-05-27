
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class Request
    {
        [Key]
        public Guid RequestId { get; set; }

        [ForeignKey("EmployeeId")]
        [Required]
        public Employee Employee { get; set; } = null!;
        public Guid EmployeeId { get; set; }

        [Unicode(false)]
        [MaxLength(30)]
        public string? Topic { get; set; }

        [Unicode(false)]
        [MaxLength(300)]
        public string? Description { get; set; }

        [Unicode(false)]
        [MaxLength(30)]
        public string? State { get; set; }

        [Unicode(false)]
        [MaxLength(30)]
        public string? Recipient { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? Comment { get; set; }

    }
}
