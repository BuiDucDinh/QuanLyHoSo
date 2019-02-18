using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
// page add webapi in .net 4.0 :https://david.gardiner.net.au/2015/08/aspnet-web-api-for-net-framework-4-in.html
/// <summary>
/// Summary description for WebApiConfig
/// </summary>
public class WebApiConfig
{
	public WebApiConfig()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void Register(HttpConfiguration config)
    {
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new
            {
                id = RouteParameter.Optional
            }
        );
        config.EnableSystemDiagnosticsTracing();
    }
}