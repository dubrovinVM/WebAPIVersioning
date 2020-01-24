using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//   Versioning by Media Type
// for this scope uncomment lines 31-34 (add MediaTypeApiVersionReader) in Startup.cs and comment other lines with AddApiVersioning
// can be: text/html, text/xml, application/json, image/jpeg etc.

//   1st variant:
//GET /api/mediatype HTTP/1.1
//host: localhost
//accept: text/plain;version=1.0

//   2nd variant:
//GET /api/mediatype HTTP/1.1
//host: localhost
//accept: text/plain;version=2.0

//  3th variant:
//POST api/mediatype?text=Hello there! HTTP/1.1
//host: localhost
//content-type: text/plain;version=2.0
//content-length: 12


namespace V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    public class MediaTypeController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Media Type VERSIONING v1.0";
    }
}

namespace V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/[controller]")]
    public class MediaTypeController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Media Type VERSIONING v2.0";

        [HttpPost]
        public string Post(string text) => text;
    }
}