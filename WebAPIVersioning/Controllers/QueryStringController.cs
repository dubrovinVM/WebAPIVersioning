using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QueryString.WebAPIVersioning
{
    //  QUERYSTRING PARAMETER VERSIONING
    //  GET /api/querystring?api-version=1.0 || /api/querystring?api-version=2.0

    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/querystring")]
    public class QueryStringParameterController : Controller
    {
        /// <summary>
        ///  Parameter Id - {int}, ID of order in DB. "api-version" - version of API ("1.0","2.0") Versioning by QUERYSTRING PARAMETER
        /// </summary>
        /// <returns>A string with a message</returns>
        ///<param name="id"></param>  
        [HttpGet]
        public string Get(int id, [FromQuery(Name = "api-version")] string apiVersion) => "QUERYSTRING PARAMETER VERSIONING v1.0!";
    }

    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/querystring")]
    public class QueryStringParameterV2Controller : Controller
    {
        /// <summary>
        ///  Parameter Id - {int}, ID of order in DB. "api-version" - version of API ("1.0","2.0"). Versioning by QUERYSTRING PARAMETER
        /// </summary>
        /// <returns>A string with a message</returns>
        ///<param name="id"></param>  
        [HttpGet]
        public string Get(int id, [FromQuery(Name = "api-version")] string apiVersion) => "QUERYSTRING PARAMETER VERSIONING v2.0!";
    }
}