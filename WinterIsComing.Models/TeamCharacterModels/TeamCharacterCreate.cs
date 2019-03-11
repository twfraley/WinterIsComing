using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Data
{
    public class TeamCharacterCreate
    {
        public int TeamCharacterId { get; set; }

        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
