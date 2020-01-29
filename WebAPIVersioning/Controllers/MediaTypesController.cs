using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPIVersioning.Models;

//   Versioning by Media Type
// can be: text/html, text/xml, application/json, image/jpeg etc.

//   1st variant:
//GET /api/mediatype HTTP/1.1
//host: localhost
//accept: text/plain;version=1.0

//   2nd variant:
//GET /api/mediatype HTTP/1.1
//host: localhost
//accept: text/plain;version=2.0


namespace V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    public class MediaTypeController : ControllerBase
    {
        [HttpPost]
        public string Post(string text) => text;
    }
}

namespace V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/[controller]")]
    public class MediaTypeController : ControllerBase
    {
        /// <summary>
        /// Parameter Id - {int}, ID of order in DB. Sending request for getting order - Versioning by Media Type
        /// </summary> 
        /// <returns>A string with a message</returns>
        ///<param name="id"></param>  
        [HttpGet]
        public string Get(int id, [FromHeader(Name = "x-api-version")] string xApiVersion) => "Media Type VERSIONING v2.0";

        /// <summary>
        /// Creates an order."x-api-version" - version of API ("2.0","3.0")
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/mediatype
        ///     {        
        ///         "orderId": 1234,
        ///         "description": "Table TGO-12",
        ///         "productCode": "A2343",
        ///         "count": 2       
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>       
        [HttpPost]
        [Produces("text/plain")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string Post([FromBody]Order oder, [FromHeader(Name = "x-api-version")]string xApiVersion) 
            => $"Your order: {oder.Description} VERSIONING v2.0";
    }
}

namespace V3
{
    [ApiVersion("3.0")]
    [ApiController]
    [Route("api/[controller]")]
    public class MediaTypeController : ControllerBase
    {
        /// <summary>
        /// Creates an order."x-api-version" - version of API ("2.0","3.0")
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /api/mediatype
        ///     {        
        ///         "orderId": 1234,
        ///         "description": "Table TGO-12",
        ///         "productCode": "A2343",
        ///         "count": 2,
        ///         "customerName":"Vasya",
        ///         "customerAddress": "Kyiv"
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>   
        [HttpPost]
        public string Post(OrderExt oderExt, [FromHeader(Name = "x-api-version")] string xApiVersion) 
            => $"Dear {oderExt.CustomerName}, your order: {oderExt.Description} VERSIONING v3.0";
    }
}