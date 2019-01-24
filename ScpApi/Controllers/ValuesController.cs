using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ScpApi.Controllers
{
    [Route("api/[controller]")]
    [DisableCors]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var lowlevelClient = new ElasticLowLevelClient();
            var person = new
            {
                FirstName = "Martijn",
                LastName = "Laarman"
            };

            // Index to /people/person/1
            var indexResponse = lowlevelClient.Index<BytesResponse>("people", "person", "1", PostData.Serializable(person)); 
            byte[] responseBytes = indexResponse.Body;
            Console.WriteLine(responseBytes.ToString());

            return new string[] { "value1", "value2", FetchResults() };
        }

        public string FetchResults()
        {
            var lowlevelClient = new ElasticLowLevelClient();
            var searchResponse = lowlevelClient.Search<StringResponse>("people", "person", PostData.Serializable(new
            {
                from = 0,
                size = 10,
                query = new
                {
                    multi_match = new
                    {
                        fields = (new string[] {"FirstName"}),
                        query = "Martijn"
                    }
                }
            }));

            var successful = searchResponse.Success;
            var responseJson = searchResponse.Body;
            return responseJson;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
