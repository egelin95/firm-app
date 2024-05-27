
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace firm_app
{
    public class AccessLevel
    {
        [Key]
        public Guid AccessLevelId { get; set; }

        public int Level { get; set; }

        [Unicode(false)]
        [MaxLength(30)]
        public string? Description { get; set; }

        [Unicode(false)]
        [MaxLength(30)]
        public string? AccessType { get; set; }


        [Unicode(false)]
        [MaxLength(100)]
        public string? Comment { get; set; }

    }
}
