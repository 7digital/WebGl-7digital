using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SevenDigital.WebGl.Controllers
{
    public class DefaultController : Controller
    {
		public ActionResult Index()
		{
			return Redirect(Url.Content("~/index.html"));
		}
	}
}
