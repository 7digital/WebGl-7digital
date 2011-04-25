using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using SevenDigital.WebGl.Models;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;
using SevenDigital.WebGl.Services;

namespace SevenDigital.WebGl.Controllers
{
	[HandleError]
	public class ImagesController : Controller
	{
		public JsonResult Artist(string search)
		{
			var apiWrapper = new ApiWrapper();
			var response = new ApiResponse();

			int id = -1;
			if (int.TryParse(search, out id))
				response = apiWrapper.TryGet(string.Format("/artist/releases?artistid={0}&imageSize=200", id));
			else
				response = apiWrapper.TryGet(string.Format("/artist/search?q={0}&imageSize=200", search));

			var images = GetImages(response);

			return Json(images, JsonRequestBehavior.AllowGet);
		}

		public JsonResult Release(string search)
		{
			var apiWrapper = new ApiWrapper();
			var response = new ApiResponse();

			int id = -1;
			if (int.TryParse(search, out id))
				response = apiWrapper.TryGet(string.Format("/release/details?releaseid={0}&imageSize=200", id));
			else
				response = apiWrapper.TryGet(string.Format("/release/search?q={0}&imageSize=200", search));

			var images = GetImages(response);

			return Json(images, JsonRequestBehavior.AllowGet);
		}

		private IEnumerable<string> GetImages(ApiResponse response)
		{
			var images = response.Xml.Descendants("image").Select(i => i.Value);

			return images;
		}
	}
}
