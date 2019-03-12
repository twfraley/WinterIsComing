using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new CharacterService(Guid.Parse(User.Identity.GetUserId()));

            if (!service.CreateCharacter(character))
                return InternalServerError();

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Put(CharacterEdit character)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new CharacterService(Guid.Parse(User.Identity.GetUserId()));

            if (!service.EditCharacter(character))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = new CharacterService(Guid.Parse(User.Identity.GetUserId()));

            if (!service.DeleteCharacter(id))
                return InternalServerError();

            return Ok();
        }


    }
}