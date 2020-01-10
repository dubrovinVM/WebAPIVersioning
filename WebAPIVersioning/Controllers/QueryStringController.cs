using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QueryString.WebAPIVersioning
{
    //  QUERYSTRING PARAMETER VERSIONING
    //  for this scope uncomment the line 30 and comment other lines with AddApiVersioning
    //  GET /api/querystring?api-version=1.0 || /api/querystring?api-version=2.0

    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/querystring")]
    public class QueryStringParameterController : Controller
    {
        [HttpGet]
        public string Get() => "QUERYSTRING PARAMETER VERSIONING v1.0!";
    }

    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/querystring")]
    public class QueryStringParameterV2Controller : Controller
    {
        [HttpGet]
        public string Get() => "QUERYSTRING PARAMETER VERSIONING v2.0!";
    }
}