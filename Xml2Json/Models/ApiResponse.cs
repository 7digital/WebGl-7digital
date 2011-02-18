using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace Xml2Json.Models
{
	public class ApiResponse
	{
		private readonly NameValueCollection _headers = new NameValueCollection();

		public string Text { get; private set; }

		public XDocument Xml { get; private set; }

		public HttpStatusCode StatusCode { get; private set; }

		public NameValueCollection Headers { get { return _headers; } }

		public ApiResponse(HttpStatusCode status, string text, NameValueCollection headers) {
			Xml = new XDocument();
			StatusCode = status;
			Text = text;
			_headers = headers ?? new NameValueCollection();

			if (!string.IsNullOrEmpty(text)) {
				Xml = XDocument.Parse(text);
			}
		}
	}
}