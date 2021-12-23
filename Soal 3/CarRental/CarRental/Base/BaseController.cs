using CarRental.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CarRental.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entity, Repository, Key> : ControllerBase
        where Entity : class
        where Repository : IRepository<Entity, Key>
    {
        private readonly Repository repository;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Entity> Get()
        {
            var ada = repository.Get();
            if (ada.Count() <= 0)
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result = ada, message = $"Data Tidak Ada" });
            }
            return Ok(ada);
        }

        [HttpGet("{Key}")]
        public ActionResult<Entity> Get(Key key)
        {
            var ada = repository.Get(key);
            if (ada != null)
            {
                return Ok(ada);
            }
            return NotFound(new { status = HttpStatusCode.NotFound, result = ada, message = $"Data Dengan  {key} Tidak Ada" });
        }
        [HttpPost]
        public ActionResult Post(Entity entity)
        {
            var result = repository.Insert(entity);
            return Ok(new { status = HttpStatusCode.OK, result = result, message = "Data Telah Ditambahkan" });
        }
        [HttpDelete("{Key}")]
        public ActionResult<Entity> Delete(Key key)
        {
            var exist = repository.Get(key);
            try
            {
                var result = repository.Delete(key);
                return Ok(new { status = HttpStatusCode.OK, result = result, message = $"Data Dengan  : {key} Dihapus" });
            }
            catch
            {
                return NotFound(new { status = HttpStatusCode.NotFound, result = exist, message = $"Data Tidak Ada" });
            }
        }
        [HttpPut("{Key}")]
        public ActionResult<Entity> Update(Entity entity, Key key)
        {
            try
            {
                var result = repository.Update(entity, key);
                return Ok(new { status = HttpStatusCode.OK, message = $"Data Telah Diupdate" });
            }
            catch
            {
                return NotFound(new { status = HttpStatusCode.NotFound, message = "Data Tersebut Tidak Ada" });
            }
        }
    }
}
