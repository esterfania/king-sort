using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingSort.Domain;
using Microsoft.AspNetCore.Mvc;

namespace KingSort.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KingsController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromBody]string[] request)
        {
            var king = new King();

            var response = king.GetSortedList(request);

            return Ok(response);
        }
    }
}