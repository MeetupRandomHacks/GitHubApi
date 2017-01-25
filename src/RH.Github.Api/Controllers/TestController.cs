using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class TestController : Controller
{

	[HttpGet]
	public static async Task<string> ProcessRepositories()
	{
		var client = new HttpClient();
		client.DefaultRequestHeaders.Accept.Clear();
		client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
		client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

		var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

		return await stringTask;
	}	
}
