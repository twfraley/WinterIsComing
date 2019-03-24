using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WinterIsComing.Models.CharacterModels;
using WinterIsComing.Services;

namespace WinterIsComing.WebApi.Controllers
{
    [RoutePrefix("api/Character")]
    public class CharacterController : ApiController
    {
        [Route("All")]
        public IHttpActionResult GetAll()
        {
            var service = new CharacterService(Guid.Parse(User.Identity.GetUserId()));
            var characters = service.GetCharacters();
            return Ok(characters);
        }

        [Route("Single/{id:int}")]
        public IHttpActionResult GetByID(int id)
        {
            var service = new CharacterService(Guid.Parse(User.Identity.GetUserId()));
            var character = service.GetCharacterById(id);
            return Ok(character);
        }

        [HttpPost]
        public IHttpActionResult Post(CharacterCreate character)
        {
            if (User.IsInRole("SuperAdmin"))
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = new CharacterService(Guid.Parse(User.Identity.GetUserId()));

                if (!service.CreateCharacter(character))
                    return InternalServerError();

                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult Put(CharacterEdit character)
        {
            if (User.IsInRole("SuperAdmin"))
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = new CharacterService(Guid.Parse(User.Identity.GetUserId()));

                if (!service.EditCharacter(character))
                    return InternalServerError();

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (User.IsInRole("SuperAdmin"))
            {
                var service = new CharacterService(Guid.Parse(User.Identity.GetUserId()));

                if (!service.DeleteCharacter(id))
                    return InternalServerError();

                return Ok();
            }
            return BadRequest();
        }

    }
}