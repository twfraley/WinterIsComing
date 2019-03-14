using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.PointValueModels
{
    public class PointValueCreate
    {
        [Required]
        public int CharacterId { get; set; }

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
