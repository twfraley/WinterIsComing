using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models
{
    public class TheoryDetail
    {
        
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Subject { get; set; }

        
        public string Content { get; set; }

        [Display(Name = "Date Created"), DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset DateCreated { get; set; }
    }
}
