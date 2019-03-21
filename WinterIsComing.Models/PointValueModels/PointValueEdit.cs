using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.PointValueModels
{
    public class PointValueEdit
    {
        public int PointValueId { get; set; }

        public int CharacterId { get; set; }

        [DisplayName("Survived the Episode")]
        public bool SurvivedEpisode { get; set; }

        [DisplayName("Appeared in the Episode")]
        public bool EpisodeAppearance { get; set; }

        [DisplayName("Killed Somebody in the Episode")]
        public bool GetKill { get; set; }

        [DisplayName("Died")]
        public bool Death { get; set; }

        [DisplayName("Killed a Main Character/White Walker/Big Kill")]
        public bool BigKill { get; set; }
    }
}
