using RH.Github.Api.Models;

namespace RH.GitHub.Api.Controllers
{
	[Route("repositorios")]
	public class RepositorioController : Controller
	{
		[HttpGet]
		public string ObterTodos()
		{
			var cliente = new HttpClient();

			cliente.DefaultRequestHeaders.Accept.Clear();
			cliente.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			cliente.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

			return cliente.GetAsync("https://api.github.com/orgs/dotnet/repos").Result;

		}	
	}
}