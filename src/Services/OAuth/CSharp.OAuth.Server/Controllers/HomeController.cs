namespace CSharp.OAuth.Server.Controllers
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;

    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        private readonly ILogger<HomeController> _logger;

        public HomeController(IWebHostEnvironment environment,
            ILogger<HomeController> logger) 
        {
            _environment = environment;

            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/idsr4/account/login?returnUrl=&internalLogin=1");

            try
            {
                _logger.LogInformation("User IsAuthenticated.");

                _logger.LogInformation($"ContentRootPath {_environment.ContentRootPath}");

                var path = $"{_environment.ContentRootPath}\\ClientApp\\dist\\index.html";

                _logger.LogInformation($"index.html path {path}");

                return PhysicalFile(path, "text/html");
            }
            catch (Exception ex)
            {
                _logger.LogError("Load SPA app fail ", ex);

                throw ex;
            }
        }
    }
}