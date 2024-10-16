using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcBlogNoticias.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "AZURE DEVOPS: https://dev.azure.com/microsoft";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Curso de Pós Graduação FIAP";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
