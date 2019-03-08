using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models
{
    public class TheoryListItem
    {
        public string Subject { get; set; }

        [Display(Name = "Date Created"), DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset DateCreated { get; set; }
    }
}
