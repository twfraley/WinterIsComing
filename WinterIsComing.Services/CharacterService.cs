using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data;
using WinterIsComing.Models.CharacterModels;

namespace WinterIsComing.Services
{
    public class CharacterService
    {
        public bool CreateCharacter(CharacterCreate model)
        {
            Character character = new Character()
            {
                CharacterName = model.CharacterName,
                House = model.House,
                ImageLink = model.ImageLink
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Characters.Add(character);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CharacterListItem> GetCharacters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Characters
                    .Select(
                        p =>
                        new CharacterListItem
                        {
                            CharacterName = p.CharacterName,
                            House = p.House,
                            ImageLink = p.ImageLink,
                        });
                return query.ToArray();
            }
        }

        public CharacterDetail GetCharacterById(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Characters
                    .Single(e => e.CharacterId == characterId);
                return
                    new CharacterDetail
                    {
                        CharacterId = entity.CharacterId,
                        CharacterName = entity.CharacterName,
                        House = entity.House,
                        ImageLink = entity.ImageLink,
                    };
            }
        }

        public bool EditCharacter(CharacterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == model.CharacterId);

                entity.CharacterName = model.CharacterName;
                entity.House = model.House;
                entity.ImageLink = model.ImageLink;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCharacter(int characterId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Characters
                        .Single(e => e.CharacterId == characterId);

                ctx.Characters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
