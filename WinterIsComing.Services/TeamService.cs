using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data;
using WinterIsComing.Models.CharacterModels;
using WinterIsComing.Models.TeamModels;

namespace WinterIsComing.Services
{
    public class TeamService
    {
        private Guid _userId;

        public TeamService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTeam(TeamCreate model)
        {
            Team team = new Team()
            {
                TeamName = model.TeamName,
                UserId = _userId,
                TotalPoints = 0
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(team);
                return ctx.SaveChanges() == 1;
            }
        }


        public List<TeamListItem> GetTeams()
        {
            IQueryable<TeamListItem> query;

            using (var ctx = new ApplicationDbContext())
            {
                query =
                    ctx
                    .Teams
                    .Select(p =>
                    new TeamListItem
                    {
                        TeamId = p.TeamId,
                        TeamName = p.TeamName,
                    });

                var list = query.ToList();

                foreach (var item in list)
                {
                    item.Characters = GenerateTeamById(item.TeamId);
                    item.TotalPoints = CalculatePoints(item.Characters);
                }

                return list;
            }
        }


        public TeamDetail GetTeamById(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .SingleOrDefault(e => e.TeamId == teamId);

                var characters = GenerateTeamById(entity.TeamId);

                return
                    new TeamDetail
                    {
                        TeamId = entity.TeamId,
                        TeamName = entity.TeamName,
                        TotalPoints = CalculatePoints(characters),
                        Characters = characters,
                        UserId = entity.UserId
                    };
            }
        }

        public bool EditTeam(TeamDetail model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == model.TeamId);

                if (entity.UserId == _userId)
                {
                    entity.TeamId = model.TeamId;
                    entity.TeamName = model.TeamName;
                    entity.TotalPoints = model.TotalPoints;

                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool DeleteTeam(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == teamId);

                if (entity.UserId == _userId)
                {
                    ctx.Teams.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<CharacterListItem> GenerateTeamById(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var characters = new List<CharacterListItem>();

                var query =
                    ctx
                    .TeamCharacters
                    .Where(q => q.TeamId == teamId)
                    .ToList();

                foreach (var item in query)
                {
                    var character = new CharacterListItem
                    {
                        CharacterId = item.CharacterId,
                        CharacterName = item.Character.CharacterName,
                        House = item.Character.House,
                        ImageLink = item.Character.ImageLink
                    };

                    characters.Add(character);
                }
                return characters;
            }
        }

        private int CalculatePoints(List<CharacterListItem> characters)
        {
            int points = 0;
            using (var ctx = new ApplicationDbContext())
            {
                foreach (var character in characters)
                {
                    var query =
                        ctx
                        .PointValues
                        .Where(r => r.CharacterId == character.CharacterId)
                        .ToList();

                    foreach (var item in query)
                    {
                        if (item.EpisodeAppearance)
                        {
                            points += 4;
                        }

                        if (item.SurvivedEpisode)
                        {
                            points += 10;
                        }

                        if (item.GetKill)
                        {
                            points += 5;
                        }

                        if (item.BigKill)
                        {
                            points += 10;
                        }

                        if (item.Death)
                        {
                            points -= 10;
                        }

                    }
                }

                return points;
            }
        }

    }
}
