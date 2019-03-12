using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.CharacterModels
{
    public class CharacterDetail
    {
        public int CharacterId { get; set; }
   
        public string CharacterName { get; set; }
        
        public string House { get; set; }
        
        public string ImageLink { get; set; }
    }
}
