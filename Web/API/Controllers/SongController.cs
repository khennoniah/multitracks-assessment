using Microsoft.AspNetCore.Mvc;
using DataAccess;
using System.Data;
using System.Linq;
using API.Models;
using System.Collections.Generic;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        
        // GET api/song
        [HttpGet("list")]
        public IEnumerable<DataRow> Get([FromQuery] RequestParams requestParams)
        {

            DataTable data = new SQL().ExecuteDT( "SELECT * FROM song ORDER BY dateCreation");

            var result = data.AsEnumerable()
                .Skip(requestParams.PageSize * (requestParams.PageNumber - 1))
                .Take(requestParams.PageSize);
            
            return result;
        } 

    }
}
