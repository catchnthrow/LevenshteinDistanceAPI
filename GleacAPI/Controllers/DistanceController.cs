using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GleacAPI.BusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Newtonsoft.Json;

namespace GleacAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class DistanceController : ControllerBase
    {
        // POST: api/Distance
        [HttpPost]
        public IActionResult Post(Input input)
        {
            var output = StringDistanceFinder.LevenshteinDistance(input.Str1, input.Str2);

            return Ok(new {message= "Success", data = JsonConvert.SerializeObject(output)});
        }
    }
}
