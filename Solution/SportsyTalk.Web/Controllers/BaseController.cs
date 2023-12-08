using Microsoft.AspNetCore.Mvc;
using SportsyTalk.Data;
using SportsyTalk.Web.Models;
using System.Diagnostics;

namespace SportsyTalk.Web.Controllers
{
    public class BaseController : Controller
    {
        internal readonly ILogger<HomeController> _logger;
        internal readonly IConfiguration _config;
        internal readonly HttpClient _http;
        public Repository Data { get; }

        public BaseController(ILogger<HomeController> logger, IConfiguration config, HttpClient httpClient)
        {
            _logger = logger;
            _config = config;
            _http = httpClient;
            string connectionString = _config.GetConnectionString("SportsyTalk") ?? throw new Exception("Database connection string is not defined");
            this.Data = new Repository(connectionString);
            
        }

    }
}