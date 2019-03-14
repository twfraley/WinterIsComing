using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinterIsComing.Models.PointValueModels;
using WinterIsComing.Services;

namespace WinterIsComing.WebApi.Controllers
{
    [RoutePrefix("api/PointValues")]
    public class ValuesController : ApiController
    {
        [Route("All")]
        public IHttpActionResult GetAll()
        {
            var service = new PointValueService(Guid.Parse(User.Identity.GetUserId()));
            var pointValue = service.GetPointValues();
            return Ok(pointValue);
        }

        // GET api/values/5
        [Route("Single/{id:int}")]
        public IHttpActionResult GetPointValuesById(int pointValueId)
        {
            var service = new PointValueService(Guid.Parse(User.Identity.GetUserId()));
            var pointValue = service.GetPointValueById(pointValueId);
            return Ok(pointValue);
        }

        [HttpPost]
        public IHttpActionResult Post(PointValueCreate pointValue)
        {
            if (User.IsInRole("SuperAdmin"))
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = new PointValueService(Guid.Parse(User.Identity.GetUserId()));

                if (!service.CreatePointValue(pointValue))
                    return InternalServerError();

                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult Put(PointValueEdit pointValue)
        {
            if (User.IsInRole("SuperAdmin"))
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = new PointValueService(Guid.Parse(User.Identity.GetUserId()));

                if (!service.EditPointValue(pointValue))
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
                var service = new PointValueService(Guid.Parse(User.Identity.GetUserId()));

                if (!service.DeletePointValue(id))
                    return InternalServerError();

                return Ok();
            }
            return BadRequest();
        }
    }
}
