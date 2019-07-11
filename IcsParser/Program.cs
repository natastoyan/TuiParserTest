using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text;

namespace IcsParser
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var site = await GetSite("https://www.icstrvl.ru/flights/379909/538625.html");
			Console.WriteLine(site);
		}

		static async Task<string> GetSite(string url)
		{
			var client = new HttpClient();

			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			Encoding.GetEncoding("windows-1251");

			var site = await client.GetStringAsync(url);
			return site;
		}
	}
}
