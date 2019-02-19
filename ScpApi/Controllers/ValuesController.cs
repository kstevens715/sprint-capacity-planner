using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using ScpApi.Models;

namespace ScpApi.Controllers
{
    [Route("api/[controller]")]
    [DisableCors]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpPost]
        public void Post([FromBody] Sprint sprint)
        {
            Console.WriteLine(sprint.Name);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(string id)
        {
            var client = BuildClient();
            IndexRecord(client, id);
            Console.WriteLine(id);
            var sp = client.Get<Sprint>(id, idx => idx.Index("sprintnewerest"));
            return new JsonResult(sp.Source);
        }

        public Nest.ElasticClient BuildClient()
        {
            var node = new Uri("http://127.0.0.1:9200");
            var settings = new ConnectionSettings(node).DefaultIndex("sprintnewerest");
            return new ElasticClient(settings);
        }

        public void IndexRecord(ElasticClient client, string id)
        {
            var sprint = new Sprint()
            {              
                Id = id,
                Name = "Spr1",
            };

            var personSprint = new TeamMemberSprint()
            {
                Name = "Kyle",
                DaysAvailableBeforeFF = 8,
                DaysAvailableAfterFF = 10,
            };

            var breakdown = new Breakdown()
            {
                Name = "Sprint 1",
                TargetPercent = 50.0m,
            };

            sprint.TeamMemberSprints.Add(personSprint);
            sprint.Breakdowns.Add(breakdown);
            var indexResponse = client.IndexDocument(sprint);
            Console.WriteLine(indexResponse.Id);
        }
    }
}
