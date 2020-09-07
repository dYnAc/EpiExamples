﻿using System;
using System.Web.Mvc;

namespace EpiExamples
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)
        }

        protected override void RegisterRoutes(System.Web.Routing.RouteCollection routes)
        {
            base.RegisterRoutes(routes);
            routes.Ignore("sitemap.xml");
            routes.Ignore("robots.txt");
        }
    }
}