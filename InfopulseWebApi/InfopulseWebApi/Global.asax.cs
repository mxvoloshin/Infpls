using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Infopulse.EntityFramework.EntityFramework;
using Infopulse.EntityFramework.Migrations;
using InfopulseWebApi.App_Start;

namespace InfopulseWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InfopulseDbContext, Configuration>());

            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            var response = app.Context.Response;

            response.AddHeader("Access-Control-Allow-Origin", HttpContext.Current.Request.Headers["Origin"] ?? "*");
            response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS, DELETE, PUT");
            response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            response.AddHeader("Access-Control-Allow-Credentials", "true");

            if (String.Compare(HttpContext.Current.Request.HttpMethod, "OPTIONS", StringComparison.OrdinalIgnoreCase) ==
                0)
            {
                response.End();
            }
        }
    }
}
