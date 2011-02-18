using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SevenDigital.Api.Xml2Json.Models;
using System.Net;
using System.IO;
using System.Configuration;

namespace SevenDigital.Api.Xml2Json.Services
{
	public class ApiWrapper
	{
		private string _apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
		private string _consumerKey = ConfigurationManager.AppSettings["ApiConsumerKey"];

		public string ApiUrl
		{
			get { return _apiUrl; }
		}

		public string ConsumerKey
		{
			get { return _consumerKey; }
		}

		public ApiResponse TryGet(string pathAndQuery)
		{
			var fullUri = ConstructApiUrl(pathAndQuery);

			using (var client = new WebClient())
			{
				try
				{
					return new ApiResponse(HttpStatusCode.OK, client.DownloadString(fullUri), client.ResponseHeaders);
				}
				catch (WebException ex)
				{
					if (ex.Status == WebExceptionStatus.ProtocolError)
						return new ApiResponse(HttpStatusCode.OK, ReadAll(ex.Response), ex.Response.Headers);
					throw;
				}
			}
		}

		private Uri ConstructApiUrl(string pathAndQuery)
		{
			var url = string.Format("{0}{1}&oauth_consumer_key={2}", ApiUrl, pathAndQuery, ConsumerKey);
			return new Uri(url);
		}

		private string ReadAll(WebResponse webResponse)
		{
			using (var reader = new StreamReader(webResponse.GetResponseStream()))
			{
				return reader.ReadToEnd();
			}
		}
	}
}