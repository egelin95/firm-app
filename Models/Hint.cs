
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class Hint
    {
        [Key]
        public Guid HintId { get; set; }

        [Unicode(false)]
        [MaxLength(25)]
        public string? Topic { get; set; }

        [Unicode(false)]
        [MaxLength(1000)]
        public string? Description { get; set; }

        public bool Anonymous { get; set; }

        [Unicode(false)]
        [MaxLength(100)]
        public string? Comment { get; set; }
    }
}
