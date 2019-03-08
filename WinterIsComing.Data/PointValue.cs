using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Data
{
    public class PointValue
    {
        [Key]
        public int PointValueId { get; set; }

        [Required]
        public bool SurvivedEpisode { get; set; }

        [Required]
        public bool EpisodeAppearance { get; set; }

        [Required]
        public bool GetKill { get; set; }

        [Required]
        public bool Death { get; set; }

        [Required]
        public bool BigKill { get; set; }
    }
}
