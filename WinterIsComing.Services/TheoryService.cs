using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterIsComing.Data;
using WinterIsComing.Models;

namespace WinterIsComing.Services
{
    public class TheoryService
    {
        private readonly Guid _userId;

        public TheoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTheory(TheoryCreate model)
        {
            var entity =
                new Theory()
                {
                    OwnerId = _userId,
                    Subject = model.Subject,
                    Content = model.Content,
                    DateCreated = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Theories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TheoryListItem> GetTheories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Theories
                    .Select(
                        p =>
                        new TheoryListItem
                        {
                            Subject = p.Subject,
                            DateCreated = p.DateCreated,
                        }).ToArray();
                return query;
            }
        }

        public bool EditTheory(TheoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Theories.FirstOrDefault(p => p.OwnerId == _userId && p.TheoryId == model.TheoryId);

                entity.Subject = model.Subject;
                entity.Content = model.Content;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTheory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Theories.Single(p => p.OwnerId == _userId && p.TheoryId == id);

                ctx.Theories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
