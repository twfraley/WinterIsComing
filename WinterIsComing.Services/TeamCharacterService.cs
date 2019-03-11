using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data;

namespace WinterIsComing.Services
{
    class TeamCharacterService
    {
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
