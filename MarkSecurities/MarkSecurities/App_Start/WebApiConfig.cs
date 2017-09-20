using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using MarkSecuritiesDataLayer;


namespace MarkSecurities
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();           
            builder.EntitySet<vIsAAA>("OlympicEx");
            builder.EntitySet<vIsAAA1>("PershingEx");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ////ODataModelBuilder builder = new ODataConventionModelBuilder();
            ////builder.EntitySet<vIsAAA>("OlympicAAA");
            ////config.Routes.MapODataServiceRoute(
            ////    routeName: "ODataRoute",
            ////    routePrefix: null,
            ////    model: builder.GetEdmModel());


        }
    }
}
