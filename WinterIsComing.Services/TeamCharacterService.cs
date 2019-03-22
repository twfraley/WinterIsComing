using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data;
using WinterIsComing.Models;
using WinterIsComing.Models.CharacterModels;

namespace WinterIsComing.Services
{
    public class TeamCharacterService
    {
        private Guid _userId;

        public TeamCharacterService(Guid userId)
        {
            _userId = userId;
        }

        // Add Character to team
        public bool AddCharacterToTeam(int characterId, int teamId)
        {
            TeamCharacter teamCharacter = new TeamCharacter
            {
                CharacterId = characterId,
                TeamId = teamId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TeamCharacters.Add(teamCharacter);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get all TeamCharacter items.  Probably not used.
        public List<TeamCharacterListItem> GetAllTeamCharacterItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.TeamCharacters.Select(p => new TeamCharacterListItem
                        {
                            TeamCharacterId = p.TeamCharacterId,
                            CharacterId = p.CharacterId,
                            TeamId = p.TeamId
                        });
                return query.ToList();
            }
        }

        // Get team by teamId
        public List<TeamCharacterListItem> GetTeamList(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.TeamCharacters.Where(e => e.TeamId == teamId).ToList();
                var teamList = new List<TeamCharacterListItem>();

                foreach (TeamCharacter item in query)
                {
                    var teamListItem = new TeamCharacterListItem
                    {
                        TeamCharacterId = item.TeamCharacterId,
                        CharacterId = item.CharacterId,
                        TeamId = item.TeamId
                    };

                    teamList.Add(teamListItem);
                }

                return teamList;
            }
        }
        
        // Get characters NOT on team
        public List<CharacterListItem> GetAvailableCharacters(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.TeamCharacters.Where(q => q.TeamId == teamId).ToList();
                var characterList = ctx.Characters.Select(c => new CharacterListItem
                {
                    CharacterId = c.CharacterId,
                    CharacterName = c.CharacterName,
                    House = c.House,
                    ImageLink = c.ImageLink
                }).ToList();

                var excludeList = new List<CharacterListItem>();
                var teamList = characterList;

                foreach (var character in characterList)
                {
                    foreach (var item in query)
                    {
                        if (character.CharacterId == item.CharacterId)
                        {
                            excludeList.Add(character);
                        }
                    }
                }

                foreach (var excludeCharacter in excludeList)
                {
                    foreach (var character in characterList)
                    {
                        if (character.CharacterId == excludeCharacter.CharacterId)
                        {
                            teamList.Remove(character);
                        }
                    }
                }

                return teamList;
            }
        }
        
        // Remove character from team
        public bool DeleteTeamCharacter(int characterId, int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.TeamCharacters.Single(e => e.CharacterId == characterId && e.TeamId == teamId);

                ctx.TeamCharacters.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
