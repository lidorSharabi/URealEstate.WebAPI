﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiURealEstate
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //IMPORTANT(enable client to call web api)
            config.EnableCors();
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
