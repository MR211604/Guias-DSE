using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace MVCPeliculas.Controllers
{
    public class HelloWorld : Controller
    {
        public string Index()
        {
            return "Esta es mi acción <b> predeterminada </b>";
        }
        public ActionResult Welcome(string nombre, string apellido, int numVeces = 1)
        {
            ViewData["nombre"] = "Hola " + nombre + " " + apellido;
            ViewData["numVeces"] = numVeces;
            return View();
        }
        public string Greeting(string nombre, int id = 1)
        {
            return HtmlEncoder.Default.Encode($"Hola {nombre}, ID: {id}");
        }

    }
}
