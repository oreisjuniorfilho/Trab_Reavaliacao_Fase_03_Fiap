using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcBlogNoticias.Controllers
{
    public class OlaMundoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BemVindo(string nome, int NumVezes)
        {
            ViewData["Mensagem"] = "Olá " + nome;
            ViewData["NumVezes"] = NumVezes;
            return View();
        }
    }
}
