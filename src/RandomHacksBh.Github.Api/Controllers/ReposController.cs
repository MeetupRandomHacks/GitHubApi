using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace RandomHacksBh.Github.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReposController : Controller
    {
        private readonly IGitHubClient _github;

        public ReposController(IGitHubClient github)
        {
            _github = github;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var repos = await _github.Repository.GetAllPublic();
                return StatusCode(200, repos);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{owner}/{name}")]
        public async Task<IActionResult> Get(string owner, string name)
        {
            try
            {
                var repos = await _github.Repository.Get(owner, name);
                return StatusCode(200, repos);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}