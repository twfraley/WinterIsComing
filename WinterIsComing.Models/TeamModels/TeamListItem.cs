using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data;

namespace WinterIsComing.Models.TeamModels
{
    public class TeamListItem
    {
        [DisplayName("Team Name")]
        public string TeamName { get; set; }

        [DisplayName("Total Team Points")]
        public int TotalPoints { get; set; }
        
        public List<Character> Characters { get; set; }
    }
}
