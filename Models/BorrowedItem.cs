
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class BorrowedItem
    {
        [Key]
        public Guid BorrowedItemId { get; set; }

        [ForeignKey("EmployeeId")]
        [Required]
        public Employee Employee { get; set; } = null!;
        public Guid EmployeeId { get; set; }
        

        [Unicode(false)]
        [MaxLength(30)]
        public string? ItemName { get; set; }

        public DateTime BorrowedDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? Comment { get; set; }

    }
}
