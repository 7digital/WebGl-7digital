﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SevenDigital.WebGl
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("static/");
			routes.IgnoreRoute("{file}.html");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}", // URL with parameters
				new { controller = "Default", action = "Index" } // Parameter defaults
			);

			routes.MapRoute(
				"Images", // Route name
				"{controller}/{action}/{search}", // URL with parameters
				new { controller = "Images", action = "Artist", search = "7515" } // Parameter defaults
			);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);
		}
	}
}