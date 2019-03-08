using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.CharacterModels
{
    public class CharacterCreate
    {
        [Required]
        public string CharacterName { get; set; }

        [Required]
        public string House { get; set; }

        [Required]
        public string ImageLink { get; set; }
    }
}
