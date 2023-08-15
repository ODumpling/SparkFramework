using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spark.Templates.Inertiajs.Application.Database;
using Spark.Templates.Inertiajs.Application.ViewModels;
using System.Diagnostics;
using InertiaCore;
using ILogger = Spark.Library.Logging.ILogger;

namespace Spark.Templates.Inertiajs.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
		private readonly DatabaseContext _db;

		public HomeController(ILogger logger, DatabaseContext db)
        {
            _logger = logger;
			_db = db;
        }

        [Route("")]
        public IActionResult Index()
		{
			return Inertia.Render("Welcome", new {});
        }

		[Authorize]
		[Route("dashboard")]
        public IActionResult Dashboard()
        {
            return Inertia.Render("Dashboard", new {});
		}
    }
}