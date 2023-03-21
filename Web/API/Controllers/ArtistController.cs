using Microsoft.AspNetCore.Mvc;
using System.Data;

using DataAccess;
using static API.Models.ArtistModel;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {

        // GET api/artist/search?name=
        [HttpGet("search")]
        public ActionResult<DataTable> Get([FromQuery] string name)
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
    }
}
