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
        public IEnumerable<Song> Get([FromQuery] RequestParams requestParams)
        {

            // get data
            DataTable data = new SQL().ExecuteDT( "SELECT * FROM song ORDER BY dateCreation");

            // this will paginate the data, but each row will still contain the whole table as an attribute
            /* IEnumerable<DataRow> rowResult = data.AsEnumerable()
                .Skip(requestParams.PageSize * (requestParams.PageNumber - 1))
                .Take(requestParams.PageSize);*/

            // convert the DataRows to Song objects and then paginate
            IEnumerable<Song> list = (from row in data.AsEnumerable() select new Song(row)).ToList();
            var objResult = list.Skip(requestParams.PageSize * (requestParams.PageNumber - 1))
                .Take(requestParams.PageSize);
            
            return objResult;
        } 
    }
}
