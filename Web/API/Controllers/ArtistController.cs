using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataAccess;
using System.Data;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    public class Artist
    {
        public string title { get; set; }
        public string biography { get; set; }
        public string imageURL { get; set; }
        public string heroURL { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {

        // GET api/artist/search
        [HttpGet("search/{name}")]
        public ActionResult<DataTable> Get(string name)
        {
            
            string[] query = {
                $"SELECT * FROM artist " +
                $"WHERE title like '%{name}%' "
            };

            DataTable data = new SQL().ExecuteDT(query[0]);

            return data;
        }

        // PUT api/artist/add
        [HttpPut("add")]
        public void Put([FromBody] Artist body)
        {
            // should check for duplicate artist name? 
            string[] query = {
                $"INSERT INTO Artist (title, biography, imageURL, heroURL) " +
                $"VALUES ('{body.title}', '{body.biography}', '{body.imageURL}', '{body.heroURL}')"
            };

            new SQL().Execute(query[0]);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
