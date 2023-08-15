using InertiaCore;
using Microsoft.AspNetCore.Mvc;
using Spark.Templates.Inertiajs.Application.ViewModels;
using System.Diagnostics;

namespace Spark.Templates.Inertiajs.Application.Controllers
{
	public class ErrorController : Controller
	{
		[Route("error")]
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return Inertia.Render("Error/PageNotFound", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[Route("access-denied")]
		public IActionResult AccessDenied()
		{
			return Inertia.Render("Error/AccessDenied");
		}

		[Route("page-not-found")]
		public IActionResult PageNotFound()
		{
			return Inertia.Render("Error/PageNotFound");
		}
	}
}
