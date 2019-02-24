using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using ScpApi.Models;
using ScpApi.Repositories;

namespace ScpApi.Controllers
{
    [Route("api/[controller]")]
    [DisableCors]
    [ApiController]
    public class SprintsController : ControllerBase
    {

        [HttpPost]
        public void Post([FromBody] Sprint sprint)
        {
            SprintRepository.SaveSprint(sprint);
            Console.WriteLine(sprint.Name);
        }

        [HttpGet("{id}")]
        public JsonResult Get(string id)
        {
            SprintRepository.IndexRecord("1234");
            Sprint Sprint = SprintRepository.GetSprint(id);

            return new JsonResult(Sprint);
        }
    }
}
