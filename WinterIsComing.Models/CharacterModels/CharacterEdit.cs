using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinterIsComing.Models.CharacterModels
{
    public class CharacterEdit
    {
        public int CharacterId { get; set; }

        [DisplayName("Character Name")]
        public string CharacterName { get; set; }


        public string House { get; set; }


        public string ImageLink { get; set; }
    }
}
