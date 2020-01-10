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

    //  for this scope uncomment lines 35-37 (add HeaderApiVersionReader) in Startup.cs and comment other lines with AddApiVersioning 
    //  once you set the version reader to use the header, you can no longer specify query string versioning 
    // api/customheaderparameter
    // GET x-api-version:2.0

    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/customheaderparameter")]
    public class CustomHeaderParameterController : Controller
    {
        [HttpGet]
        public string Get() => "Custom Header parameter VERSIONING v1.0!";
    }

    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/customheaderparameter")]
    public class CustomHeaderParameterV2Controller : Controller
    {
        [HttpGet]
        public string Get() => "Custom Header parameter VERSIONING v2.0!";
    }
}

