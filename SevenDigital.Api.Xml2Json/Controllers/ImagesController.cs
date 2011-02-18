using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using SevenDigital.Api.Xml2Json.Models;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;
using SevenDigital.Api.Xml2Json.Services;

namespace SevenDigital.Api.Xml2Json.Controllers
{
	[HandleError]
	public class ImagesController : Controller
	{
		public JsonResult Artists(string search = "Eels")
		{
			var images = GetImages("artist", search);

			return Json(images, JsonRequestBehavior.AllowGet);
		}

		public JsonResult Releases(string search = "Daisies of the galaxy")
		{
			var images = GetImages("release", search);
			return Json(images, JsonRequestBehavior.AllowGet);
		}

		private IEnumerable<string> GetImages(string searchType, string search)
		{
			var apiWrapper = new ApiWrapper();
			var response = apiWrapper.TryGet(string.Format("/{0}/search?q={1}&imageSize=200", searchType, search));

			var images = response.Xml.Descendants("image").Select(i => i.Value);

			return images;
		}
	}
}
