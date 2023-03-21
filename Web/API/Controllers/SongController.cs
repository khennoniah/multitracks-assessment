using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Linq;
using System.Collections.Generic;

using DataAccess;
using static API.Models.SongModel;


namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {

        // GET api/song/list?pageSize=&pageNumber=
        [HttpGet("list")]
        public IEnumerable<DataRow> Get([FromQuery] RequestParams requestParams)
        {

            DataTable data = new SQL().ExecuteDT( "SELECT * FROM song ORDER BY dateCreation");

            // Each row will have the full table included as an attribute. Extracting only the
            // necessary information would probably be worthwile
            var result = data.AsEnumerable()
                .Skip(requestParams.PageSize * (requestParams.PageNumber - 1))
                .Take(requestParams.PageSize);
            
            return result;
        } 
    }
}
