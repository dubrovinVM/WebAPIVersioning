using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UrlPath.WebAPIVersioning
{
    // URL PATH SEGMENT VERSIONING
    // GET /api/v[1|2|3]/urlpath

    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UrlPathController : Controller
    {
        [HttpGet]
        public string Get() => "URL PATH SEGMENT VERSIONING v1";
    }

    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/urlpath")]
    public class UrlPath2Controller : Controller
    {
        [HttpGet]
        public string Get() => "URL PATH SEGMENT VERSIONING v2";

        [HttpGet, MapToApiVersion("3.0")]
        public string GetV3() => "URL PATH SEGMENT VERSIONING v3";
    }
}





