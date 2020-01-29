using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIVersioning.Controllers
{
    //  Versioning using Custom Header parameter
    // api/customheaderparameter
    // GET x-api-version:2.0

    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/customheaderparameter")]
    public class CustomHeaderParameterController : Controller
    {
        /// <summary>
        /// Parameter Id - {int}, ID of order in DB. "x-api-version" - version of API ("1.0","2.0"). Showing Versioning by Custom Header parameter
        /// </summary>
        /// <returns>A string with a message</returns>
        ///<param name="id"></param>  
        [HttpGet]
        public string Get(int id, [FromHeader(Name = "x-api-version")]string xApiVersion) => "Custom Header parameter VERSIONING v1.0!";
    }

    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/customheaderparameter")]
    public class CustomHeaderParameterV2Controller : Controller
    {
        /// <summary>
        /// Parameter Id - {int}, ID of order in DB. "x-api-version" - version of API ("1.0","2.0"). Showing Versioning by Custom Header parameter
        /// </summary>
        /// <returns>A string with a message</returns>
        ///<param name="id"></param>  
        [HttpGet]
        public string Get(int id, [FromHeader(Name = "x-api-version")]string xApiVersion) => "Custom Header parameter VERSIONING v2.0!";
    }
}

