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

            // get data
            DataTable data = new SQL().ExecuteDT( "SELECT * FROM song ORDER BY dateCreation");

            // Pagination:
            // grab "PageSize" number of items starting with
            // the item at index [PageSize * (PageNumber - 1)]
            var result = data.AsEnumerable()
                .Skip(requestParams.PageSize * (requestParams.PageNumber - 1))
                .Take(requestParams.PageSize);
            
            return result;
        } 
    }
}
