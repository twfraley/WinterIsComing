using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data;

namespace WinterIsComing.Models
{
    public class TeamCharacterListItem
    {
        public int TeamCharacterId { get; set; }

        public int CharacterId { get; set; }
        public virtual Character Character { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
