using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data;
using WinterIsComing.Models.PointValueModels;

namespace WinterIsComing.Services
{
    public class PointValueService
    {
        private Guid _userId;

        public PointValueService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePointValue(PointValueCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var character = ctx.Characters.Single(p => p.CharacterId == model.CharacterId);
                PointValue pointValue = new PointValue()
                {
                    CharacterId = character.CharacterId,
                    EpisodeAppearance = model.EpisodeAppearance,
                    SurvivedEpisode = model.SurvivedEpisode,
                    GetKill = model.GetKill,
                    Death = model.Death,
                    BigKill = model.BigKill
                };
                ctx.PointValues.Add(pointValue);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<PointValueListItem> GetPointValues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PointValues.Select(p =>
                        new PointValueListItem
                        {
                            PointValueId = p.PointValueId,
                            CharacterId = p.CharacterId,
                            EpisodeAppearance = p.EpisodeAppearance,
                            SurvivedEpisode = p.SurvivedEpisode,
                            GetKill = p.GetKill,
                            Death = p.Death,
                            BigKill = p.BigKill
                        });
                return query.ToList();
            }
        }

        public PointValueDetail GetPointValueById(int pointValueId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PointValues.Single(e => e.PointValueId == pointValueId);

                return
                    new PointValueDetail
                    {
                        EpisodeAppearance = entity.EpisodeAppearance,
                        SurvivedEpisode = entity.SurvivedEpisode,
                        GetKill = entity.GetKill,
                        Death = entity.Death,
                        BigKill = entity.BigKill
                    };
            }
        }

        public bool EditPointValue(PointValueEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PointValues.Single(e => e.PointValueId == model.PointValueId);

                entity.EpisodeAppearance = model.EpisodeAppearance;
                entity.SurvivedEpisode = model.SurvivedEpisode;
                entity.GetKill = model.GetKill;
                entity.Death = model.Death;
                entity.BigKill = model.BigKill;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePointValue(int pointValueId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PointValues.Single(e => e.PointValueId == pointValueId);

                ctx.PointValues.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
