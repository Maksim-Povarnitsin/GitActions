using LabMiAu.Common;
using LabMiAu.Data;
using LabMiAu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace LabMiAu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Authenticate(string email)
        {
            return RedirectPermanent(GoogleApiHelper.GetOauthUri(email));
        }
        public IActionResult OauthCallback(string code, string error, string state)
        {
            try
            {
                if (!string.IsNullOrEmpty(code))
                {
                    ViewBag.Message = "Successfull: " + code;
                }
                if (!string.IsNullOrEmpty(error))
                {
                    ViewBag.Message = "Error: " + error;
                }
                if (!string.IsNullOrEmpty(state))
                {
                    ViewBag.MailAddress = state;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}