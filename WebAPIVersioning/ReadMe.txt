Use dotnet-sdk-core 3.1.10
For Swagger used Swashbuckle: https://localhost:44319/swagger/index.html
Other documental services for RESTful API:
- www.apiary.io
- www.mashape.com
- http://www.dexy.it/
- http://turnapi.com/
- help pages from Microsoft https://docs.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/creating-api-help-pages

API versioning - Proof of concept

To version your service, you simply need to decorate your controller with the appropriate API version information.

API versioning does not have a direct influence on routing. The way that you create and define routes remains unchanged. The key difference is that routes may now overlap depending on whether you are using convention-based routing, attribute-based routing, or both. In the case of attribute routing, multiple controllers will define the same route. The default services in each flavor of ASP.NET assumes a one-to-one mapping between routes and controllers and, therefore, considers duplicate routes to be ambiguous. The API versioning services replace the default implementations and allow controllers to also be disambiguated by API version. Although multiple routes may match a request, they are expected to be distinguishable by API version. If the routes cannot be disambiguated, this is likely a developer mistake and the behavior is the same as the default implementation.


Routing Methods:

- Attribute-based routing	
- Convention-based routing	
- Attribute and convention-based routing (mixed)

Convention-based routing is normally defined by inferring the route from the name of the controller type without the Controller suffix. For example, HelloWorldController is interpreted as the HelloWorld route. Unfortunately, this causes an issue for service API versioning if you want split the implementation across different types. To address this issue, you can decorate convention-based controllers that are versioned into different types using the ControllerNameAttribute. In the strictest sense, this is not a convention, but this is only way to make a new controller type match an existing convention-based route with an API version. For example:

[ApiVersion( "2.0" )]
[ControllerName( "HelloWorld" )]
public class HelloWorld2Controller : Controller
{
    public string Get() => "Hello world v2.0!";
}

API Versioning Methods:

- Query String Versioning (default) : [ApiVersion( "2.0" )] => /api/helloworld?api-version=2.0
- URL Path Versioning: [ApiVersion( "1.0" )] [Route( "api/v{version:apiVersion}/[controller]" )] => /api/v[1|2|3]/helloworld
- Header Versioning:
                       once you set the version reader to use the header, you can no longer specify `Query String Versioning`
                       
                       public void ConfigureServices( IServiceCollection services )
                       {
                           services.AddMvc();
                           services.AddApiVersioning(o => o.ApiVersionReader = new HeaderApiVersionReader("api-version"));
                       }
- Media Type Versioning
- DEPRECATING (This advertises that 1.0 is going away soon and that folks should consider 2.0. The response headers advertise this fact!): [ApiVersion( "2.0" )] [ApiVersion( "1.0", Deprecated = true )]

Ignoring API Versioning for some endpoints: [ApiVersionNeutral]

