using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Data
{
    public class Theory
    {
        [Key]
        public int TheoryId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset DateCreated { get; set; }
    }
}
