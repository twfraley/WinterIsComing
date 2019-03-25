using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WinterIsComing.Models.TeamModels;
using WinterIsComing.Services;

namespace WinterIsComing.WebApi.Controllers
{
    [RoutePrefix("api/Team")]
    public class TeamController : ApiController
    {
        [Route("All")]
        public IHttpActionResult GetAll()
        {
            var service = new TeamService(Guid.Parse(User.Identity.GetUserId()));
            var teams = service.GetTeams();
            return Ok(teams);
        }

        [Route("Single/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var service = new TeamService(Guid.Parse(User.Identity.GetUserId()));
            var team = service.GetTeamById(id);
            return Ok(team);
        }

        [HttpPost]
        public IHttpActionResult Post(TeamCreate team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new TeamService(Guid.Parse(User.Identity.GetUserId()));

            if (!service.CreateTeam(team))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(TeamDetail team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new TeamService(Guid.Parse(User.Identity.GetUserId()));

            if (!service.EditTeam(team))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = new TeamService(Guid.Parse(User.Identity.GetUserId()));

            if (!service.DeleteTeam(id))
                return InternalServerError();

            return Ok();
        }

    }
}
