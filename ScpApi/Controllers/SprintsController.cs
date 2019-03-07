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
        public JsonResult Create([FromBody] Sprint sprint)
        {
            SprintRepository.SaveSprint(sprint);

            return new JsonResult(sprint);
        }

        [HttpGet()]
        public JsonResult Index()
        {
            var sprints = SprintRepository.GetAllSprints();

            return new JsonResult(sprints);
        }

        [HttpGet("{id}")]
        public JsonResult Show(string id)
        {
            SprintRepository.IndexRecord("1234");
            Sprint sprint = SprintRepository.GetSprint(id);

            return new JsonResult(sprint);
        }
    }
}
