using LabMiAu.Common;
using LabMiAu.Data;
using LabMiAu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Net;
using System.Text;

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
        public IActionResult Authenticate()
        {
            return RedirectPermanent(GoogleApiHelper.GetOauthUri());
        }

        public IActionResult OauthCallback(string code, string error, string state)
        {
            try
            {
                if (!string.IsNullOrEmpty(state))
                {
                    byte[] buffer = Encoding.ASCII.GetBytes("code=" + code +
                        "&client_id=" + GoogleApiHelper.ClientId +
                        "&client_secret=" + GoogleApiHelper.ClientSecret +
                        "&redirect_uri=" + GoogleApiHelper.RedirectUri +
                        "&grant_type=authorization_code");
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
                    req.Method = "POST";
                    req.ContentType = "application/x-www-form-urlencoded";
                    req.ContentLength = buffer.Length;

                    Stream strm = req.GetRequestStream();
                    strm.Write(buffer, 0, buffer.Length);
                    strm.Close();
                    HttpWebResponse resp = null;
                    try
                    {
                        resp = (HttpWebResponse)req.GetResponse();
                    }
                    catch (Exception exception)
                    {
                        ViewBag.Message = "Error: Invalid request";
                    }
                    if (resp != null)
                    {
                        if (GoogleApiHelper.State == state && resp.StatusCode == HttpStatusCode.OK)
                        {
                            if (!string.IsNullOrEmpty(code))
                            {
                                ViewBag.Message = "Successfull: " + code;
                            }
                            if (!string.IsNullOrEmpty(error))
                            {
                                ViewBag.Message = "Error: " + error;
                            }
                        }
                        else
                        {
                            ViewBag.Message = "Error: Invalid data";
                        }
                    }
                    else
                        ViewBag.Message = "Error: Invalid request";
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