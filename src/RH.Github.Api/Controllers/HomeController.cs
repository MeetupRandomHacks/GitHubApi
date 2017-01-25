using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{

	public IActionResult Index()
	{
		
		return View();
	}

	[HttpGet]
	public string GetGitHubRepositories() 
	{
		var client = new HttpClient();
		client.DefaultRequestHeaders.Accept.Clear();
		client.DefaultRequestHeaders.Accept.Add(
			new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
		client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

		var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

		return stringTask.Result;
	}
}
