using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinterIsComing.Models;
using WinterIsComing.Services;

namespace WinterIsComing.WebApi.Controllers
{
    [RoutePrefix("api/TeamCharacter")]
    public class TeamCharacterController : ApiController
    {
        [Route("All")]
        public IHttpActionResult GetAll()
        {
            var service = new TeamCharacterService(Guid.Parse(User.Identity.GetUserId()));
            var team = service.GetAllTeamCharacterItems();
            return Ok(team);
        }

        [Route("Single/{id:int}")]
        public IHttpActionResult GetTeamMembersByTeamId(int teamId)
        {
            var service = new TeamCharacterService(Guid.Parse(User.Identity.GetUserId()));
            var team = service.GetTeamList(teamId);
            return Ok(team);
        }

        // TK & JA - Would we rather feed this a model or just characterId and teamId?
        [HttpPost]
        public IHttpActionResult Post(TeamCharacterCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new TeamCharacterService(Guid.Parse(User.Identity.GetUserId()));

            if (!service.AddCharacterToTeam(model.CharacterId, model.TeamId))
                return InternalServerError();

            return Ok();
        }

        // TK & JA - same question as above (at HttpPost) here
        [HttpDelete]
        public IHttpActionResult Delete(int characterId, int teamId)
        {
            var service = new TeamCharacterService(Guid.Parse(User.Identity.GetUserId()));

            if (!service.DeleteTeamCharacter(characterId, teamId))
                return InternalServerError();

            return Ok();
        }

    }
}
